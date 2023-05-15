namespace ManagmentOfProducts
{
    partial class MainForm
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
            panelMenu = new Panel();
            btnWineCellerMenu = new Button();
            btnUsersMenu = new Button();
            btnAccessoriesMenu = new Button();
            btnCollectionsMenu = new Button();
            btnExit = new Button();
            btnWinesMenu = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            lbTitle = new Label();
            panelForm = new Panel();
            panelMenu.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Maroon;
            panelMenu.Controls.Add(btnWineCellerMenu);
            panelMenu.Controls.Add(btnUsersMenu);
            panelMenu.Controls.Add(btnAccessoriesMenu);
            panelMenu.Controls.Add(btnCollectionsMenu);
            panelMenu.Controls.Add(btnExit);
            panelMenu.Controls.Add(btnWinesMenu);
            panelMenu.Controls.Add(panel2);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(242, 803);
            panelMenu.TabIndex = 0;
            // 
            // btnWineCellerMenu
            // 
            btnWineCellerMenu.BackColor = Color.Maroon;
            btnWineCellerMenu.Dock = DockStyle.Top;
            btnWineCellerMenu.FlatAppearance.BorderSize = 0;
            btnWineCellerMenu.FlatStyle = FlatStyle.Flat;
            btnWineCellerMenu.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnWineCellerMenu.ForeColor = Color.Gainsboro;
            btnWineCellerMenu.Location = new Point(0, 349);
            btnWineCellerMenu.Name = "btnWineCellerMenu";
            btnWineCellerMenu.Size = new Size(242, 64);
            btnWineCellerMenu.TabIndex = 8;
            btnWineCellerMenu.Text = "Wine Cellars";
            btnWineCellerMenu.UseVisualStyleBackColor = false;
            btnWineCellerMenu.Click += btnWineCellerMenu_Click;
            // 
            // btnUsersMenu
            // 
            btnUsersMenu.BackColor = Color.Maroon;
            btnUsersMenu.Dock = DockStyle.Top;
            btnUsersMenu.FlatAppearance.BorderSize = 0;
            btnUsersMenu.FlatStyle = FlatStyle.Flat;
            btnUsersMenu.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsersMenu.ForeColor = Color.Gainsboro;
            btnUsersMenu.Location = new Point(0, 285);
            btnUsersMenu.Name = "btnUsersMenu";
            btnUsersMenu.Size = new Size(242, 64);
            btnUsersMenu.TabIndex = 7;
            btnUsersMenu.Text = "Users";
            btnUsersMenu.UseVisualStyleBackColor = false;
            btnUsersMenu.Click += btnUsersMenu_Click;
            // 
            // btnAccessoriesMenu
            // 
            btnAccessoriesMenu.BackColor = Color.Maroon;
            btnAccessoriesMenu.Dock = DockStyle.Top;
            btnAccessoriesMenu.FlatAppearance.BorderSize = 0;
            btnAccessoriesMenu.FlatStyle = FlatStyle.Flat;
            btnAccessoriesMenu.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAccessoriesMenu.ForeColor = Color.Gainsboro;
            btnAccessoriesMenu.Location = new Point(0, 221);
            btnAccessoriesMenu.Name = "btnAccessoriesMenu";
            btnAccessoriesMenu.Size = new Size(242, 64);
            btnAccessoriesMenu.TabIndex = 6;
            btnAccessoriesMenu.Text = "Accessories";
            btnAccessoriesMenu.UseVisualStyleBackColor = false;
            btnAccessoriesMenu.Click += btnAccessoriesMenu_Click;
            // 
            // btnCollectionsMenu
            // 
            btnCollectionsMenu.BackColor = Color.Maroon;
            btnCollectionsMenu.Dock = DockStyle.Top;
            btnCollectionsMenu.FlatAppearance.BorderSize = 0;
            btnCollectionsMenu.FlatStyle = FlatStyle.Flat;
            btnCollectionsMenu.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCollectionsMenu.ForeColor = Color.Gainsboro;
            btnCollectionsMenu.Location = new Point(0, 157);
            btnCollectionsMenu.Name = "btnCollectionsMenu";
            btnCollectionsMenu.Size = new Size(242, 64);
            btnCollectionsMenu.TabIndex = 5;
            btnCollectionsMenu.Text = "Collections";
            btnCollectionsMenu.UseVisualStyleBackColor = false;
            btnCollectionsMenu.Click += btnCollectionsMenu_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Maroon;
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.Gainsboro;
            btnExit.Location = new Point(0, 739);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(242, 64);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnWinesMenu
            // 
            btnWinesMenu.BackColor = Color.Maroon;
            btnWinesMenu.Dock = DockStyle.Top;
            btnWinesMenu.FlatAppearance.BorderSize = 0;
            btnWinesMenu.FlatStyle = FlatStyle.Flat;
            btnWinesMenu.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnWinesMenu.ForeColor = Color.Gainsboro;
            btnWinesMenu.Location = new Point(0, 93);
            btnWinesMenu.Name = "btnWinesMenu";
            btnWinesMenu.Size = new Size(242, 64);
            btnWinesMenu.TabIndex = 3;
            btnWinesMenu.Text = "Wines";
            btnWinesMenu.UseVisualStyleBackColor = false;
            btnWinesMenu.Click += btnWinesMenu_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Maroon;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(242, 93);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Brown;
            pictureBox1.Image = Properties.Resources._7G_wines_removebg_preview;
            pictureBox1.Location = new Point(0, -22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 149);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.Maroon;
            panelTitleBar.Controls.Add(lbTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(242, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1190, 93);
            panelTitleBar.TabIndex = 1;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.ForeColor = Color.Gainsboro;
            lbTitle.Location = new Point(538, 27);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(96, 38);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Home";
            // 
            // panelForm
            // 
            panelForm.BackColor = SystemColors.ButtonShadow;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(242, 93);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1190, 710);
            panelForm.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1432, 803);
            Controls.Add(panelForm);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            MaximumSize = new Size(1450, 850);
            MinimumSize = new Size(1450, 850);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panel2;
        private Button btnExit;
        private Button btnWinesMenu;
        private Panel panelTitleBar;
        private PictureBox pictureBox1;
        private Button btnAccessoriesMenu;
        private Button btnCollectionsMenu;
        private Panel panelForm;
        private Button btnUsersMenu;
        private Label lbTitle;
        private Button btnWineCellerMenu;
    }
}