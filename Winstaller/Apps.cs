using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using CSJson.Atalho;
using System.Linq;

namespace Winstaller
{
    public partial class Apps : UserControl
    {
        // Event to request the host form to rebuild the combined tree
        public event Action RequestTreeRebuild;
        bool exists = false;
        string strapps;
        List<Winstaller.appdata.Appdata> apps; // app list owned by Apps control

        public Apps()
        {
            InitializeComponent();
        }

        // Select a specific atalho for editing inside the Atalho tab
        public void SelectAtalho(string appName, string shortcutName)
        {
            var app = apps.Find(a => a.name == appName);
            if (app == null) return;
            // populate app fields
            txtname.Text = app.name;
            nametb.Text = app.name;
            vertb.Text = app.version;
            pathtb.Text = app.path;
            // set atalho fields
            tbshname.Text = shortcutName;
            tbades.Text = ""; // description for this specific shortcut not stored; leave empty
            // switch tab to Atalho
            try { this.tabControl1.SelectedIndex = 1; } catch { }
        }

        // Prepare UI to create a new atalho for an optional appName
        public void PrepareNewAtalho(string appName = null)
        {
            tbshname.Text = string.Empty;
            tbades.Text = string.Empty;
            if (!string.IsNullOrEmpty(appName))
            {
                // populate path/name for selected app
                var app = apps.Find(a => a.name == appName);
                if (app != null)
                {
                    txtname.Text = app.name;
                    nametb.Text = app.name;
                    pathtb.Text = app.path;
                }
            }
            try { this.tabControl1.SelectedIndex = 1; } catch { }
        }

        public List<string> GetAppNames()
        {
            return apps.Select(a => a.name).ToList();
        }

        public void SelectApp(string name)
        {
            var app = apps.Find(a => a.name == name);
            if (app == null) return;
            txtname.Text = app.name;
            nametb.Text = app.name;
            vertb.Text = app.version;
            pathtb.Text = app.path;
            tbshname.Text = app.atname;
            tbades.Text = app.atdes;
        }

        // optional: refresh internal shortcuts UI (if you add one inside Apps)
        public void RefreshShortcutsList(List<string> appNames)
        {
            // no-op by default; implement if Apps contains a shortcuts subcontrol
        }

        public void ShowProgramTab()
        {
            try { this.tabControl1.SelectedIndex = 0; }
            catch { }
        }

        public void ShowAtalhoTab()
        {
            try { this.tabControl1.SelectedIndex = 1; }
            catch { }
        }

        // Initialize apps from file - called by Form1 on load
        public void InitializeApps()
        {
            if (!File.Exists("apps.json"))
            {
                apps = new List<Winstaller.appdata.Appdata>();
                File.WriteAllText("apps.json", JsonSerializer.Serialize(apps));
            }

            strapps = File.ReadAllText("apps.json");
            apps = JsonSerializer.Deserialize<List<Winstaller.appdata.Appdata>>(strapps) ?? new List<Winstaller.appdata.Appdata>();
            // ensure atalhos lists exist
            foreach (var a in apps)
                if (a.atalhos == null) a.atalhos = new List<string>();
            TreeUpdate();
        }

        private Winstaller.appdata.Appdata jsonget(string path)
        {
            return apps.Find(x => x.path == path);
        }

        private void jsonload()
        {
            File.WriteAllText("apps.json", JsonSerializer.Serialize(apps));
            strapps = File.ReadAllText("apps.json");
            apps = JsonSerializer.Deserialize<List<Winstaller.appdata.Appdata>>(strapps) ?? new List<Winstaller.appdata.Appdata>();
            foreach (var a in apps)
                if (a.atalhos == null) a.atalhos = new List<string>();
            TreeUpdate();
        }

        public bool AddShortcutToApp(string appName, string shortcutName)
        {
            var app = apps.Find(x => x.name == appName);
            if (app == null) return false;
            if (app.atalhos == null) app.atalhos = new List<string>();
            app.atalhos.Add(shortcutName);
            jsonload();
            return true;
        }

        public List<string> GetAtalhosForApp(string appName)
        {
            var app = apps.Find(x => x.name == appName);
            if (app == null || app.atalhos == null) return new List<string>();
            return new List<string>(app.atalhos);
        }

        public void OnTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            var app = apps.Find(x => x.name == e.Node.Text);
            if (app != null)
            {
                txtname.Text = e.Node.Text;
                nametb.Text = e.Node.Text;
                vertb.Text = app.version;
                pathtb.Text = app.path;
                tbshname.Text = app.atname;
                tbades.Text = app.atdes;
            }
            exists = true;
        }

        private void folderReset()
        {
            exists = false;
            txtname.Text = "Name";
            nametb.Text = "";
            pathtb.Text = "";
            tbshname.Text = "";
            tbades.Text = "";
        }

        private void TreeUpdate()
        {
            RequestTreeRebuild?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var app = apps.Find(x => x.path == pathtb.Text);
            if (app != null)
            {
                app.name = nametb.Text;
                app.version = vertb.Text;
                app.path = pathtb.Text;
                TreeUpdate();
            }
            else
            {
                Winstaller.appdata.Appdata aad = new Winstaller.appdata.Appdata();
                aad.path = pathtb.Text;
                aad.name = nametb.Text;
                aad.version = vertb.Text;
                apps.Add(aad);
                TreeUpdate();
            }

            jsonload();
            this.Refresh();
        }

        // Public wrappers so Form1 can trigger control actions without reflection
        public void ResetFields() => folderReset();
        public void TreeUpdatePublic() => TreeUpdate();
        public void DoSaveEdit() => button1_Click(null, EventArgs.Empty);
        public void DoCreateShortcut() => button2_Click(null, EventArgs.Empty);

        private void vertb_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            var app = jsonget(pathtb.Text);
            if (app != null)
            {
                app.atname = tbshname.Text;
                app.atdes = tbades.Text;

                jsonload();

                DesktopAtalho ash = new DesktopAtalho(app.path, Path.GetDirectoryName(app.path), app.atdes, app.atname);
            }
            else
            {
                MessageBox.Show("Programa não encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void tbades_TextChanged(object sender, EventArgs e) { }
    }
}
