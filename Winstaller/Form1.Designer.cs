namespace Winstaller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            treeView1 = new TreeView();
            apps1 = new Apps();
            menu = new MenuStrip();
            appsToolStripMenuItem = new ToolStripMenuItem();
            addProgramToolStripMenuItem = new ToolStripMenuItem();
            addShortcutToolStripMenuItem = new ToolStripMenuItem();
            createToolStripMenuItem = new ToolStripMenuItem();
            folderToolStripMenuItem = new ToolStripMenuItem();
            commandToolStripMenuItem = new ToolStripMenuItem();
            leftPanel = new Panel();
            menu.SuspendLayout();
            leftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(160, 450);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // apps1
            // 
            apps1.Location = new Point(166, 27);
            apps1.Name = "apps1";
            apps1.Size = new Size(367, 397);
            apps1.TabIndex = 3;
            apps1.Load += apps1_Load;
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { appsToolStripMenuItem });
            menu.Location = new Point(160, 0);
            menu.Name = "menu";
            menu.Size = new Size(640, 24);
            menu.TabIndex = 1;
            menu.Text = "menuStrip1";
            // 
            // appsToolStripMenuItem
            // 
            appsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addProgramToolStripMenuItem, addShortcutToolStripMenuItem, createToolStripMenuItem });
            appsToolStripMenuItem.Name = "appsToolStripMenuItem";
            appsToolStripMenuItem.Size = new Size(46, 20);
            appsToolStripMenuItem.Text = "Apps";
            // 
            // addProgramToolStripMenuItem
            // 
            addProgramToolStripMenuItem.Name = "addProgramToolStripMenuItem";
            addProgramToolStripMenuItem.Size = new Size(145, 22);
            addProgramToolStripMenuItem.Text = "Add Program";
            addProgramToolStripMenuItem.Click += addProgramToolStripMenuItem_Click;
            // 
            // addShortcutToolStripMenuItem
            // 
            addShortcutToolStripMenuItem.Name = "addShortcutToolStripMenuItem";
            addShortcutToolStripMenuItem.Size = new Size(145, 22);
            addShortcutToolStripMenuItem.Text = "Add Shortcut";
            addShortcutToolStripMenuItem.Click += addShortcutToolStripMenuItem_Click;
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { folderToolStripMenuItem, commandToolStripMenuItem });
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(145, 22);
            createToolStripMenuItem.Text = "Create";
            // 
            // folderToolStripMenuItem
            // 
            folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            folderToolStripMenuItem.Size = new Size(131, 22);
            folderToolStripMenuItem.Text = "Folder";
            folderToolStripMenuItem.Click += folderToolStripMenuItem_Click;
            // 
            // commandToolStripMenuItem
            // 
            commandToolStripMenuItem.Name = "commandToolStripMenuItem";
            commandToolStripMenuItem.Size = new Size(131, 22);
            commandToolStripMenuItem.Text = "Command";
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(treeView1);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(160, 450);
            leftPanel.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menu);
            Controls.Add(leftPanel);
            Controls.Add(apps1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menu;
            Name = "Form1";
            Text = "Home";
            Load += Form1_Load;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            leftPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private MenuStrip menu;
        private ToolStripMenuItem appsToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem folderToolStripMenuItem;
        private ToolStripMenuItem commandToolStripMenuItem;
        private ToolStripMenuItem addProgramToolStripMenuItem;
        private ToolStripMenuItem addShortcutToolStripMenuItem;
        private Apps apps1;
        
        private Panel leftPanel;
    }
}
