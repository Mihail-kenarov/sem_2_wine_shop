namespace ManagmentOfProducts.Forms
{
    partial class OrderForm
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
            lbOrders = new ListBox();
            btnFulfillOrder = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbOrders
            // 
            lbOrders.FormattingEnabled = true;
            lbOrders.ItemHeight = 15;
            lbOrders.Location = new Point(402, 37);
            lbOrders.Name = "lbOrders";
            lbOrders.Size = new Size(577, 379);
            lbOrders.TabIndex = 0;
            lbOrders.DoubleClick += lbOrders_DoubleClick;
            // 
            // btnFulfillOrder
            // 
            btnFulfillOrder.Location = new Point(144, 248);
            btnFulfillOrder.Name = "btnFulfillOrder";
            btnFulfillOrder.Size = new Size(154, 47);
            btnFulfillOrder.TabIndex = 1;
            btnFulfillOrder.Text = "Fulfill Order";
            btnFulfillOrder.UseVisualStyleBackColor = true;
            btnFulfillOrder.Click += btnFulfillOrder_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(402, 9);
            label1.Name = "label1";
            label1.Size = new Size(241, 15);
            label1.TabIndex = 2;
            label1.Text = "Double tap to view the products for an order";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 482);
            Controls.Add(label1);
            Controls.Add(btnFulfillOrder);
            Controls.Add(lbOrders);
            Name = "OrderForm";
            Text = "OrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbOrders;
        private Button btnFulfillOrder;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label1;
    }
}