using System.Xml.Serialization;
using System.Text.Json;
using Winstaller.appdata;
using CSJson.Atalho;
namespace Winstaller
{

    public partial class Form1 : Form
    {
        private bool shortcutsUiVisible = false;
        // Form1 delegates app management to Apps user control

        public Form1()
        {
            InitializeComponent();
        }
        // Form1 no longer holds app state; Apps control manages it.
        private void Form1_Load(object sender, EventArgs e)
        {
            // inicializa lista de apps dentro do user control Apps
            apps1.InitializeApps();
            // subscribe to Apps requests
            apps1.RequestTreeRebuild += RebuildTree;
            // initialize shortcuts control
            var appNames = apps1.GetType().GetMethod("GetAppNames", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)?.Invoke(apps1, null) as List<string>;
            if (appNames != null)
            {
                // Shortcuts UI is now part of Apps control; no separate shortcuts1
            }
            shortcutsUiVisible = false;

            // build combined tree view
            BuildCombinedTree();

            // garantir que o MenuStrip fique visível e no topo
            try
            {
                menu.Dock = DockStyle.Top;
                menu.Visible = true;
                menu.BringToFront();
            }
            catch { }
        }

        // Called by Shortcuts control to add a shortcut into Apps' appdata
        public bool AddShortcutToApp(string appName, string shortcutName)
        {
            var m = apps1.GetType().GetMethod("AddShortcutToApp", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (m == null) return false;
            var res = m.Invoke(apps1, new object[] { appName, shortcutName });
            return res is bool b && b;
        }

        private void BuildCombinedTree()
        {
            // preserve selection if any
            string selPath = treeView1.SelectedNode?.FullPath;

            treeView1.Nodes.Clear();
            TreeNode appsNode = new TreeNode("Apps");
            var appNames = apps1.GetType().GetMethod("GetAppNames", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)?.Invoke(apps1, null) as List<string>;
            if (appNames != null)
            {
                foreach (var a in appNames)
                    appsNode.Nodes.Add(a);
            }
            // refresh internal shortcuts UI (now inside Apps control) if needed
            if (appNames != null)
            {
                // call Apps method to refresh its internal shortcut UI if implemented
                var m = apps1.GetType().GetMethod("RefreshShortcutsList", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (m != null)
                {
                    try { m.Invoke(apps1, new object[] { appNames }); } catch { }
                }
            }
            TreeNode atalhosNode = new TreeNode("Atalhos");
            // get atalhos from apps data
            if (appNames != null)
            {
                foreach (var a in appNames)
                {
                    var atalhos = apps1.GetAtalhosForApp(a);
                    if (atalhos != null && atalhos.Count > 0)
                    {
                        TreeNode appParent = new TreeNode(a);
                        foreach (var sh in atalhos)
                            appParent.Nodes.Add(sh);
                        atalhosNode.Nodes.Add(appParent);
                    }
                }
            }

            treeView1.Nodes.Add(appsNode);
            // always add Atalhos node (even if empty)
            if (atalhosNode.Nodes.Count == 0)
            {
                atalhosNode.Nodes.Add(new TreeNode("(nenhum)"));
            }
            treeView1.Nodes.Add(atalhosNode);
            treeView1.ExpandAll();

            // try to restore previous selection
            if (!string.IsNullOrEmpty(selPath))
            {
                var toSelect = FindNodeByFullPath(treeView1.Nodes, selPath);
                if (toSelect != null)
                    treeView1.SelectedNode = toSelect;
            }
        }

        private TreeNode FindNodeByFullPath(TreeNodeCollection nodes, string fullPath)
        {
            foreach (TreeNode n in nodes)
            {
                if (n.FullPath == fullPath) return n;
                var found = FindNodeByFullPath(n.Nodes, fullPath);
                if (found != null) return found;
            }
            return null;
        }

        // called by Apps when internal data changes to rebuild the full tree
        public void RebuildTree()
        {
            BuildCombinedTree();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Only switch to Apps view on app selection. Do not auto-show Shortcuts UI.
            if (e.Node.Parent != null && e.Node.Parent.Text == "Apps")
            {
                apps1.Visible = true;
                apps1.SelectApp(e.Node.Text);
            }
            else if (e.Node.Parent != null && e.Node.Parent.Text == "Atalhos")
            {
                // selected an app node under Atalhos: show that app in Apps
                apps1.Visible = true;
                apps1.SelectApp(e.Node.Text);
            }
            else if (e.Node.Parent != null && e.Node.Parent.Parent != null && e.Node.Parent.Parent.Text == "Atalhos")
            {
                // selected a specific shortcut node: open atalho editor in Apps control
                apps1.Visible = true;
                apps1.SelectAtalho(e.Node.Parent.Text, e.Node.Text);
            }

        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apps1?.ResetFields();
        }

        private void addProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show Program tab in Apps
            apps1?.ShowProgramTab();
        }

        private void addShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Atalho tab and prepare new atalho (no separate Shortcuts control)
            apps1.PrepareNewAtalho();
        }
        private void treeupd()
        {
            // Use Apps control tree update
            apps1?.TreeUpdatePublic();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // forwarded to Apps control
            apps1?.DoSaveEdit();
        }

        private void vertb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            apps1?.DoCreateShortcut();
        }

        // Called by Apps control to update tree from internal list
        public void UpdateTreeNodes(List<string> names)
        {
            treeView1.Nodes.Clear();
            TreeNode appsnode = new TreeNode("Apps");
            foreach (var n in names)
                appsnode.Nodes.Add(n);
            treeView1.Nodes.Add(appsnode);
            treeView1.ExpandAll();
        }

        private void tbades_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void apps1_Load(object sender, EventArgs e)
        {

        }
    }
}
