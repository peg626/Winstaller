namespace Winstaller
{
    partial class Apps
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Program = new TabPage();
            panel1 = new Panel();
            pathtb = new TextBox();
            vertb = new TextBox();
            button1 = new Button();
            nametb = new TextBox();
            txtname = new Label();
            Atalho = new TabPage();
            tbades = new TextBox();
            button2 = new Button();
            label1 = new Label();
            comboshty = new ComboBox();
            tbshname = new TextBox();
            tabControl1 = new TabControl();
            Program.SuspendLayout();
            panel1.SuspendLayout();
            Atalho.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // Program
            // 
            Program.Controls.Add(panel1);
            Program.Location = new Point(4, 24);
            Program.Name = "Program";
            Program.Padding = new Padding(3);
            Program.Size = new Size(423, 372);
            Program.TabIndex = 0;
            Program.Text = "Programa";
            Program.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(pathtb);
            panel1.Controls.Add(vertb);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(nametb);
            panel1.Controls.Add(txtname);
            panel1.Location = new Point(21, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 328);
            panel1.TabIndex = 2;
            // 
            // pathtb
            // 
            pathtb.Location = new Point(66, 172);
            pathtb.Name = "pathtb";
            pathtb.PlaceholderText = "Path";
            pathtb.Size = new Size(100, 23);
            pathtb.TabIndex = 5;
            // 
            // vertb
            // 
            vertb.Location = new Point(66, 143);
            vertb.Name = "vertb";
            vertb.PlaceholderText = "Version";
            vertb.Size = new Size(100, 23);
            vertb.TabIndex = 4;
            vertb.TextChanged += vertb_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(85, 276);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nametb
            // 
            nametb.Location = new Point(66, 114);
            nametb.Name = "nametb";
            nametb.PlaceholderText = "Name";
            nametb.Size = new Size(100, 23);
            nametb.TabIndex = 2;
            // 
            // txtname
            // 
            txtname.AutoSize = true;
            txtname.Location = new Point(287, 213);
            txtname.Name = "txtname";
            txtname.Size = new Size(39, 15);
            txtname.TabIndex = 0;
            txtname.Text = "Name";
            // 
            // Atalho
            // 
            Atalho.Controls.Add(tbades);
            Atalho.Controls.Add(button2);
            Atalho.Controls.Add(label1);
            Atalho.Controls.Add(comboshty);
            Atalho.Controls.Add(tbshname);
            Atalho.Location = new Point(4, 24);
            Atalho.Name = "Atalho";
            Atalho.Padding = new Padding(3);
            Atalho.Size = new Size(423, 372);
            Atalho.TabIndex = 1;
            Atalho.Text = "Atalho";
            Atalho.UseVisualStyleBackColor = true;
            // 
            // tbades
            // 
            tbades.Location = new Point(6, 27);
            tbades.Name = "tbades";
            tbades.PlaceholderText = "Descrição";
            tbades.Size = new Size(100, 23);
            tbades.TabIndex = 4;
            tbades.TextChanged += tbades_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(6, 167);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Criar atalho";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 94);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo de atalho";
            label1.Click += label1_Click;
            // 
            // comboshty
            // 
            comboshty.FormattingEnabled = true;
            comboshty.Items.AddRange(new object[] { "Desktop", "Start Menu" });
            comboshty.Location = new Point(6, 121);
            comboshty.Name = "comboshty";
            comboshty.Size = new Size(121, 23);
            comboshty.TabIndex = 1;
            // 
            // tbshname
            // 
            tbshname.Location = new Point(6, 56);
            tbshname.Name = "tbshname";
            tbshname.PlaceholderText = "Nome do atalho";
            tbshname.Size = new Size(100, 23);
            tbshname.TabIndex = 0;
            tbshname.TextChanged += textBox1_TextChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Program);
            tabControl1.Controls.Add(Atalho);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(431, 400);
            tabControl1.TabIndex = 3;
            // 
            // Apps
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "Apps";
            Size = new Size(431, 400);
            Program.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Atalho.ResumeLayout(false);
            Atalho.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private Panel panel1;
        private TextBox pathtb;
        private TextBox vertb;
        private Button button1;
        private TextBox nametb;
        private Label txtname;
        private TextBox tbades;
        private Button button2;
        private ComboBox comboshty;
        private TextBox tbshname;
        private TabPage Program;
        private TabPage Atalho;
        private Label label1;
    }
}
