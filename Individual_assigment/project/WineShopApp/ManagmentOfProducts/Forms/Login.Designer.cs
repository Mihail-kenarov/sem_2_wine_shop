namespace ManagmentOfProducts.Forms
{
    partial class Login
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(339, 268);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(248, 27);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(339, 366);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(248, 27);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(339, 243);
            label1.Name = "label1";
            label1.Size = new Size(100, 22);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(339, 341);
            label2.Name = "label2";
            label2.Size = new Size(94, 22);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(349, 51);
            label3.Name = "label3";
            label3.Size = new Size(227, 34);
            label3.TabIndex = 4;
            label3.Text = "Welcome back to";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Brown;
            pictureBox2.Image = Properties.Resources._7G_wines_removebg_preview;
            pictureBox2.Location = new Point(333, 88);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(254, 152);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Maroon;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.Gainsboro;
            btnLogin.Location = new Point(376, 434);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(173, 37);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Log in ";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Brown;
            ClientSize = new Size(939, 553);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            MaximumSize = new Size(957, 600);
            MinimizeBox = false;
            MinimumSize = new Size(957, 600);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private Button btnLogin;
    }
}