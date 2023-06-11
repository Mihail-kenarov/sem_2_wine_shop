namespace ManagmentOfProducts.Forms
{
    partial class ProductsCollectionForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnRemoveProduct = new Button();
            label8 = new Label();
            label6 = new Label();
            lbProductCollections = new ListBox();
            btnAddAccToPC = new Button();
            btnAddWineToPC = new Button();
            lbChosenProducts = new ListBox();
            btnAddPC = new Button();
            label3 = new Label();
            txtCollectionEvent = new TextBox();
            txtCollectionDescription = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtCollectionType = new TextBox();
            nudCollectionPrice = new NumericUpDown();
            label7 = new Label();
            txtAddCollectionAmount = new TextBox();
            txtAddCollectionName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lbAccessoryChoicePC = new ListBox();
            lbWineChoicePC = new ListBox();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCollectionPrice).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 2);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1061, 486);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnRemoveProduct);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(lbProductCollections);
            tabPage1.Controls.Add(btnAddAccToPC);
            tabPage1.Controls.Add(btnAddWineToPC);
            tabPage1.Controls.Add(lbChosenProducts);
            tabPage1.Controls.Add(btnAddPC);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtCollectionEvent);
            tabPage1.Controls.Add(txtCollectionDescription);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtCollectionType);
            tabPage1.Controls.Add(nudCollectionPrice);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(txtAddCollectionAmount);
            tabPage1.Controls.Add(txtAddCollectionName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(lbAccessoryChoicePC);
            tabPage1.Controls.Add(lbWineChoicePC);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1053, 458);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Add";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.Location = new Point(211, 319);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(192, 44);
            btnRemoveProduct.TabIndex = 96;
            btnRemoveProduct.Text = "Remove Product";
            btnRemoveProduct.UseVisualStyleBackColor = true;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(725, 19);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 95;
            label8.Text = "Wines:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(436, 19);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 94;
            label6.Text = "Accessories:";
            // 
            // lbProductCollections
            // 
            lbProductCollections.FormattingEnabled = true;
            lbProductCollections.ItemHeight = 15;
            lbProductCollections.Location = new Point(436, 358);
            lbProductCollections.Margin = new Padding(3, 2, 3, 2);
            lbProductCollections.Name = "lbProductCollections";
            lbProductCollections.Size = new Size(541, 94);
            lbProductCollections.TabIndex = 93;
            // 
            // btnAddAccToPC
            // 
            btnAddAccToPC.Location = new Point(13, 293);
            btnAddAccToPC.Margin = new Padding(3, 2, 3, 2);
            btnAddAccToPC.Name = "btnAddAccToPC";
            btnAddAccToPC.Size = new Size(192, 44);
            btnAddAccToPC.TabIndex = 90;
            btnAddAccToPC.Text = "Add an Accessory";
            btnAddAccToPC.UseVisualStyleBackColor = true;
            btnAddAccToPC.Click += btnAddAccToPC_Click;
            // 
            // btnAddWineToPC
            // 
            btnAddWineToPC.Location = new Point(13, 342);
            btnAddWineToPC.Margin = new Padding(3, 2, 3, 2);
            btnAddWineToPC.Name = "btnAddWineToPC";
            btnAddWineToPC.Size = new Size(192, 44);
            btnAddWineToPC.TabIndex = 89;
            btnAddWineToPC.Text = "Add a wine";
            btnAddWineToPC.UseVisualStyleBackColor = true;
            btnAddWineToPC.Click += btnAddWineToPC_Click;
            // 
            // lbChosenProducts
            // 
            lbChosenProducts.FormattingEnabled = true;
            lbChosenProducts.ItemHeight = 15;
            lbChosenProducts.Location = new Point(436, 254);
            lbChosenProducts.Margin = new Padding(3, 2, 3, 2);
            lbChosenProducts.Name = "lbChosenProducts";
            lbChosenProducts.Size = new Size(541, 94);
            lbChosenProducts.TabIndex = 88;
            // 
            // btnAddPC
            // 
            btnAddPC.Location = new Point(127, 391);
            btnAddPC.Margin = new Padding(3, 2, 3, 2);
            btnAddPC.Name = "btnAddPC";
            btnAddPC.Size = new Size(192, 44);
            btnAddPC.TabIndex = 87;
            btnAddPC.Text = "Add a collection";
            btnAddPC.UseVisualStyleBackColor = true;
            btnAddPC.Click += btnAddPC_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 153);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 86;
            label3.Text = "Event:";
            // 
            // txtCollectionEvent
            // 
            txtCollectionEvent.Location = new Point(95, 148);
            txtCollectionEvent.Margin = new Padding(3, 2, 3, 2);
            txtCollectionEvent.Name = "txtCollectionEvent";
            txtCollectionEvent.Size = new Size(178, 23);
            txtCollectionEvent.TabIndex = 85;
            // 
            // txtCollectionDescription
            // 
            txtCollectionDescription.Location = new Point(95, 185);
            txtCollectionDescription.Margin = new Padding(3, 2, 3, 2);
            txtCollectionDescription.Multiline = true;
            txtCollectionDescription.Name = "txtCollectionDescription";
            txtCollectionDescription.Size = new Size(178, 73);
            txtCollectionDescription.TabIndex = 84;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 185);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 83;
            label4.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 125);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 82;
            label5.Text = "Type:";
            // 
            // txtCollectionType
            // 
            txtCollectionType.Location = new Point(95, 120);
            txtCollectionType.Margin = new Padding(3, 2, 3, 2);
            txtCollectionType.Name = "txtCollectionType";
            txtCollectionType.Size = new Size(178, 23);
            txtCollectionType.TabIndex = 81;
            // 
            // nudCollectionPrice
            // 
            nudCollectionPrice.DecimalPlaces = 2;
            nudCollectionPrice.Location = new Point(95, 92);
            nudCollectionPrice.Margin = new Padding(3, 2, 3, 2);
            nudCollectionPrice.Name = "nudCollectionPrice";
            nudCollectionPrice.Size = new Size(178, 23);
            nudCollectionPrice.TabIndex = 80;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 93);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 79;
            label7.Text = "Price:";
            // 
            // txtAddCollectionAmount
            // 
            txtAddCollectionAmount.Location = new Point(95, 60);
            txtAddCollectionAmount.Margin = new Padding(3, 2, 3, 2);
            txtAddCollectionAmount.Name = "txtAddCollectionAmount";
            txtAddCollectionAmount.Size = new Size(178, 23);
            txtAddCollectionAmount.TabIndex = 36;
            // 
            // txtAddCollectionName
            // 
            txtAddCollectionName.Location = new Point(95, 34);
            txtAddCollectionName.Margin = new Padding(3, 2, 3, 2);
            txtAddCollectionName.Name = "txtAddCollectionName";
            txtAddCollectionName.Size = new Size(178, 23);
            txtAddCollectionName.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 62);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 37;
            label2.Text = "Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 36);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 35;
            label1.Text = "Name:";
            // 
            // lbAccessoryChoicePC
            // 
            lbAccessoryChoicePC.FormattingEnabled = true;
            lbAccessoryChoicePC.ItemHeight = 15;
            lbAccessoryChoicePC.Location = new Point(436, 36);
            lbAccessoryChoicePC.Margin = new Padding(3, 2, 3, 2);
            lbAccessoryChoicePC.Name = "lbAccessoryChoicePC";
            lbAccessoryChoicePC.Size = new Size(252, 199);
            lbAccessoryChoicePC.TabIndex = 33;
            // 
            // lbWineChoicePC
            // 
            lbWineChoicePC.FormattingEnabled = true;
            lbWineChoicePC.ItemHeight = 15;
            lbWineChoicePC.Location = new Point(725, 36);
            lbWineChoicePC.Margin = new Padding(3, 2, 3, 2);
            lbWineChoicePC.Name = "lbWineChoicePC";
            lbWineChoicePC.Size = new Size(252, 199);
            lbWineChoicePC.TabIndex = 32;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1053, 458);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Edit";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ProductsCollectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 482);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductsCollectionForm";
            Text = "Products Collections";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCollectionPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox txtAddCollectionAmount;
        private TextBox txtAddCollectionName;
        private Label label2;
        private Label label1;
        private ListBox lbAccessoryChoicePC;
        private ListBox lbWineChoicePC;
        private TabPage tabPage2;
        private Label label5;
        private TextBox txtCollectionType;
        private NumericUpDown nudCollectionPrice;
        private Label label7;
        private Label label3;
        private TextBox txtCollectionEvent;
        private TextBox txtCollectionDescription;
        private Label label4;
        private Button btnAddPC;
        private Button btnAddAccToPC;
        private Button btnAddWineToPC;
        private ListBox lbChosenProducts;
        private ListBox lbProductCollections;
        private Label label8;
        private Label label6;
        private Button btnRemoveProduct;
    }
}