namespace ManagmentOfProducts.Forms
{
    partial class AccessoryForm
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
            btnDeleteAccessory = new Button();
            btnUpdateAccessory = new Button();
            btnAddAccessory = new Button();
            lbAccessory = new ListBox();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            nudAcessoryPrice = new NumericUpDown();
            label7 = new Label();
            label5 = new Label();
            txtAcessoryType = new TextBox();
            txtAccessoryName = new TextBox();
            txtAccessoryAmount = new TextBox();
            txtAccessoryDescription = new TextBox();
            btnLoadAccessory = new Button();
            txtAccessoryIdPick = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudAcessoryPrice).BeginInit();
            SuspendLayout();
            // 
            // btnDeleteAccessory
            // 
            btnDeleteAccessory.Location = new Point(314, 428);
            btnDeleteAccessory.Name = "btnDeleteAccessory";
            btnDeleteAccessory.Size = new Size(310, 43);
            btnDeleteAccessory.TabIndex = 74;
            btnDeleteAccessory.Text = "Delete Accessory";
            btnDeleteAccessory.UseVisualStyleBackColor = true;
            btnDeleteAccessory.Click += btnDeleteAccessory_Click;
            // 
            // btnUpdateAccessory
            // 
            btnUpdateAccessory.Location = new Point(314, 258);
            btnUpdateAccessory.Name = "btnUpdateAccessory";
            btnUpdateAccessory.Size = new Size(310, 43);
            btnUpdateAccessory.TabIndex = 73;
            btnUpdateAccessory.Text = "Update Accessory";
            btnUpdateAccessory.UseVisualStyleBackColor = true;
            btnUpdateAccessory.Click += btnUpdateAccessory_Click;
            // 
            // btnAddAccessory
            // 
            btnAddAccessory.Location = new Point(23, 258);
            btnAddAccessory.Name = "btnAddAccessory";
            btnAddAccessory.Size = new Size(271, 43);
            btnAddAccessory.TabIndex = 72;
            btnAddAccessory.Text = "Add Accessory";
            btnAddAccessory.UseVisualStyleBackColor = true;
            btnAddAccessory.Click += btnAddAccessory_Click;
            // 
            // lbAccessory
            // 
            lbAccessory.FormattingEnabled = true;
            lbAccessory.ItemHeight = 20;
            lbAccessory.Location = new Point(662, 44);
            lbAccessory.Name = "lbAccessory";
            lbAccessory.Size = new Size(423, 504);
            lbAccessory.TabIndex = 71;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 124);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 64;
            label4.Text = "Description:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 88);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 62;
            label2.Text = "Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 49);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 60;
            label1.Text = "Name:";
            // 
            // nudAcessoryPrice
            // 
            nudAcessoryPrice.DecimalPlaces = 2;
            nudAcessoryPrice.Location = new Point(410, 47);
            nudAcessoryPrice.Name = "nudAcessoryPrice";
            nudAcessoryPrice.Size = new Size(203, 27);
            nudAcessoryPrice.TabIndex = 76;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(360, 49);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 75;
            label7.Text = "Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(355, 92);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 78;
            label5.Text = "Type:";
            // 
            // txtAcessoryType
            // 
            txtAcessoryType.Location = new Point(410, 85);
            txtAcessoryType.Name = "txtAcessoryType";
            txtAcessoryType.Size = new Size(203, 27);
            txtAcessoryType.TabIndex = 77;
            // 
            // txtAccessoryName
            // 
            txtAccessoryName.Location = new Point(121, 47);
            txtAccessoryName.Name = "txtAccessoryName";
            txtAccessoryName.Size = new Size(203, 27);
            txtAccessoryName.TabIndex = 79;
            // 
            // txtAccessoryAmount
            // 
            txtAccessoryAmount.Location = new Point(121, 85);
            txtAccessoryAmount.Name = "txtAccessoryAmount";
            txtAccessoryAmount.Size = new Size(203, 27);
            txtAccessoryAmount.TabIndex = 80;
            // 
            // txtAccessoryDescription
            // 
            txtAccessoryDescription.Location = new Point(121, 124);
            txtAccessoryDescription.Multiline = true;
            txtAccessoryDescription.Name = "txtAccessoryDescription";
            txtAccessoryDescription.Size = new Size(203, 96);
            txtAccessoryDescription.TabIndex = 81;
            // 
            // btnLoadAccessory
            // 
            btnLoadAccessory.Location = new Point(23, 428);
            btnLoadAccessory.Name = "btnLoadAccessory";
            btnLoadAccessory.Size = new Size(271, 43);
            btnLoadAccessory.TabIndex = 82;
            btnLoadAccessory.Text = "Load Accessory";
            btnLoadAccessory.UseVisualStyleBackColor = true;
            btnLoadAccessory.Click += btnLoadAccessory_Click;
            // 
            // txtAccessoryIdPick
            // 
            txtAccessoryIdPick.Location = new Point(104, 381);
            txtAccessoryIdPick.Name = "txtAccessoryIdPick";
            txtAccessoryIdPick.Size = new Size(147, 27);
            txtAccessoryIdPick.TabIndex = 83;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 384);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 84;
            label6.Text = "Select ID:";
            // 
            // AccessoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 643);
            Controls.Add(label6);
            Controls.Add(txtAccessoryIdPick);
            Controls.Add(btnLoadAccessory);
            Controls.Add(txtAccessoryDescription);
            Controls.Add(txtAccessoryAmount);
            Controls.Add(txtAccessoryName);
            Controls.Add(label5);
            Controls.Add(txtAcessoryType);
            Controls.Add(nudAcessoryPrice);
            Controls.Add(label7);
            Controls.Add(btnDeleteAccessory);
            Controls.Add(btnUpdateAccessory);
            Controls.Add(btnAddAccessory);
            Controls.Add(lbAccessory);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AccessoryForm";
            Text = "Accessory";
            ((System.ComponentModel.ISupportInitialize)nudAcessoryPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDeleteAccessory;
        private Button btnUpdateAccessory;
        private Button btnAddAccessory;
        private ListBox lbAccessory;
        private Label label3;
        private TextBox txtWineCellerEmail;
        private Label label4;
        private TextBox txtWineCellerWS;
        private Label label2;
        private TextBox txtWineCellerYC;
        private Label label1;
        private TextBox txtWineCellerName;
        private NumericUpDown nudAcessoryPrice;
        private Label label7;
        private Label label5;
        private TextBox txtAcessoryType;
        private TextBox txtAccessoryName;
        private TextBox txtAccessoryAmount;
        private TextBox txtAccessoryDescription;
        private Button btnLoadAccessory;
        private TextBox txtAccessoryIdPick;
        private Label label6;
    }
}