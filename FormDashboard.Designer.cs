namespace TUGAS_UAS2
{
    partial class FormDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            panelMenu = new Panel();
            btnHasil = new FontAwesome.Sharp.IconButton();
            btnJadwal = new FontAwesome.Sharp.IconButton();
            btnData = new FontAwesome.Sharp.IconButton();
            btnInput = new FontAwesome.Sharp.IconButton();
            btnDashboard = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnHome = new PictureBox();
            panelTitleBar = new Panel();
            button1 = new Button();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHome).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(0, 0, 64);
            panelMenu.Controls.Add(btnHasil);
            panelMenu.Controls.Add(btnJadwal);
            panelMenu.Controls.Add(btnData);
            panelMenu.Controls.Add(btnInput);
            panelMenu.Controls.Add(btnDashboard);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 653);
            panelMenu.TabIndex = 0;
            // 
            // btnHasil
            // 
            btnHasil.Dock = DockStyle.Top;
            btnHasil.FlatAppearance.BorderSize = 0;
            btnHasil.FlatStyle = FlatStyle.Flat;
            btnHasil.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHasil.ForeColor = Color.Gainsboro;
            btnHasil.IconChar = FontAwesome.Sharp.IconChar.ChartGantt;
            btnHasil.IconColor = Color.Gainsboro;
            btnHasil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHasil.IconSize = 32;
            btnHasil.ImageAlign = ContentAlignment.MiddleLeft;
            btnHasil.Location = new Point(0, 380);
            btnHasil.Name = "btnHasil";
            btnHasil.Padding = new Padding(10, 0, 20, 0);
            btnHasil.Size = new Size(220, 60);
            btnHasil.TabIndex = 5;
            btnHasil.Text = "Hasil Panen";
            btnHasil.TextAlign = ContentAlignment.MiddleLeft;
            btnHasil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHasil.UseVisualStyleBackColor = true;
            btnHasil.Click += btnHasil_Click;
            // 
            // btnJadwal
            // 
            btnJadwal.Dock = DockStyle.Top;
            btnJadwal.FlatAppearance.BorderSize = 0;
            btnJadwal.FlatStyle = FlatStyle.Flat;
            btnJadwal.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnJadwal.ForeColor = Color.Gainsboro;
            btnJadwal.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnJadwal.IconColor = Color.Gainsboro;
            btnJadwal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnJadwal.IconSize = 32;
            btnJadwal.ImageAlign = ContentAlignment.MiddleLeft;
            btnJadwal.Location = new Point(0, 320);
            btnJadwal.Name = "btnJadwal";
            btnJadwal.Padding = new Padding(10, 0, 20, 0);
            btnJadwal.Size = new Size(220, 60);
            btnJadwal.TabIndex = 4;
            btnJadwal.Text = "Jadwal";
            btnJadwal.TextAlign = ContentAlignment.MiddleLeft;
            btnJadwal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnJadwal.UseVisualStyleBackColor = true;
            btnJadwal.Click += btnJadwal_Click;
            // 
            // btnData
            // 
            btnData.Dock = DockStyle.Top;
            btnData.FlatAppearance.BorderSize = 0;
            btnData.FlatStyle = FlatStyle.Flat;
            btnData.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnData.ForeColor = Color.Gainsboro;
            btnData.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnData.IconColor = Color.Gainsboro;
            btnData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnData.IconSize = 32;
            btnData.ImageAlign = ContentAlignment.MiddleLeft;
            btnData.Location = new Point(0, 260);
            btnData.Name = "btnData";
            btnData.Padding = new Padding(10, 0, 20, 0);
            btnData.Size = new Size(220, 60);
            btnData.TabIndex = 3;
            btnData.Text = "Data";
            btnData.TextAlign = ContentAlignment.MiddleLeft;
            btnData.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnData.UseVisualStyleBackColor = true;
            btnData.Click += btnData_Click;
            // 
            // btnInput
            // 
            btnInput.Dock = DockStyle.Top;
            btnInput.FlatAppearance.BorderSize = 0;
            btnInput.FlatStyle = FlatStyle.Flat;
            btnInput.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInput.ForeColor = Color.Gainsboro;
            btnInput.IconChar = FontAwesome.Sharp.IconChar.Inbox;
            btnInput.IconColor = Color.Gainsboro;
            btnInput.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInput.IconSize = 32;
            btnInput.ImageAlign = ContentAlignment.MiddleLeft;
            btnInput.Location = new Point(0, 200);
            btnInput.Name = "btnInput";
            btnInput.Padding = new Padding(10, 0, 20, 0);
            btnInput.Size = new Size(220, 60);
            btnInput.TabIndex = 2;
            btnInput.Text = "Input";
            btnInput.TextAlign = ContentAlignment.MiddleLeft;
            btnInput.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInput.UseVisualStyleBackColor = true;
            btnInput.Click += btnInput_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.Gainsboro;
            btnDashboard.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            btnDashboard.IconColor = Color.Gainsboro;
            btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashboard.IconSize = 32;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 140);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 20, 0);
            btnDashboard.Size = new Size(220, 60);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 140);
            panel1.TabIndex = 1;
            // 
            // btnHome
            // 
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(12, 22);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(192, 103);
            btnHome.SizeMode = PictureBoxSizeMode.Zoom;
            btnHome.TabIndex = 1;
            btnHome.TabStop = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 0, 64);
            panelTitleBar.Controls.Add(button1);
            panelTitleBar.Controls.Add(lblTitleChildForm);
            panelTitleBar.Controls.Add(iconCurrentChildForm);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1060, 75);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(915, 10);
            button1.Name = "button1";
            button1.Size = new Size(63, 59);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleChildForm.ForeColor = Color.Gainsboro;
            lblTitleChildForm.Location = new Point(63, 31);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(69, 23);
            lblTitleChildForm.TabIndex = 1;
            lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(0, 0, 64);
            iconCurrentChildForm.ForeColor = Color.Turquoise;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.Turquoise;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.Location = new Point(25, 22);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(32, 32);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(220, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(1060, 65);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(847, 19);
            label2.Name = "label2";
            label2.Size = new Size(179, 28);
            label2.TabIndex = 1;
            label2.Text = "Dashboard / Home";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 19);
            label1.Name = "label1";
            label1.Size = new Size(114, 28);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(0, 0, 64);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(220, 140);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1060, 513);
            panelDesktop.TabIndex = 3;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 653);
            Controls.Add(panelDesktop);
            Controls.Add(panel2);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            ForeColor = Color.White;
            Name = "FormDashboard";
            Text = "Form3";
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHome).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnHasil;
        private FontAwesome.Sharp.IconButton btnJadwal;
        private FontAwesome.Sharp.IconButton btnData;
        private FontAwesome.Sharp.IconButton btnInput;
        private PictureBox btnHome;
        private Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblTitleChildForm;
        private Panel panel2;
        private Panel panelDesktop;
        private Button button1;
        private Label label2;
        private Label label1;
    }
}