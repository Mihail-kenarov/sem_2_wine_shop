namespace ManagmentOfProducts.Forms
{
    partial class UserForm
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
            lbUsers = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUserUsername = new TextBox();
            txtUserPassword = new TextBox();
            cbUserRole = new ComboBox();
            txtUserID = new TextBox();
            label4 = new Label();
            btnAddUser = new Button();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            txtUserFN = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 20;
            lbUsers.Location = new Point(696, 37);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(343, 464);
            lbUsers.TabIndex = 0;
            lbUsers.DoubleClick += lbUsers_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 165);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 221);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 283);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 3;
            label3.Text = "Role:";
            // 
            // txtUserUsername
            // 
            txtUserUsername.Location = new Point(182, 162);
            txtUserUsername.Name = "txtUserUsername";
            txtUserUsername.Size = new Size(208, 27);
            txtUserUsername.TabIndex = 5;
            // 
            // txtUserPassword
            // 
            txtUserPassword.Location = new Point(182, 221);
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.Size = new Size(208, 27);
            txtUserPassword.TabIndex = 6;
            // 
            // cbUserRole
            // 
            cbUserRole.FormattingEnabled = true;
            cbUserRole.Items.AddRange(new object[] { "CEO", "Employee" });
            cbUserRole.Location = new Point(182, 283);
            cbUserRole.Name = "cbUserRole";
            cbUserRole.Size = new Size(208, 28);
            cbUserRole.TabIndex = 7;
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(182, 60);
            txtUserID.Name = "txtUserID";
            txtUserID.ReadOnly = true;
            txtUserID.Size = new Size(208, 27);
            txtUserID.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(149, 63);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 8;
            label4.Text = "ID:";
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(130, 340);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(283, 55);
            btnAddUser.TabIndex = 10;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(130, 418);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(283, 55);
            btnDeleteUser.TabIndex = 11;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(130, 500);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(283, 55);
            btnUpdateUser.TabIndex = 12;
            btnUpdateUser.Text = "Update User";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // txtUserFN
            // 
            txtUserFN.Location = new Point(182, 112);
            txtUserFN.Name = "txtUserFN";
            txtUserFN.Size = new Size(208, 27);
            txtUserFN.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 115);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 13;
            label5.Text = "Full name:";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 643);
            Controls.Add(txtUserFN);
            Controls.Add(label5);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnAddUser);
            Controls.Add(txtUserID);
            Controls.Add(label4);
            Controls.Add(cbUserRole);
            Controls.Add(txtUserPassword);
            Controls.Add(txtUserUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbUsers);
            Name = "UserForm";
            Text = "UserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbUsers;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUserUsername;
        private TextBox txtUserPassword;
        private ComboBox cbUserRole;
        private TextBox txtUserID;
        private Label label4;
        private Button btnAddUser;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private TextBox txtUserFN;
        private Label label5;
    }
}