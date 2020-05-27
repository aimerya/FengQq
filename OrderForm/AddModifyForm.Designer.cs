namespace OrderForm
{
    partial class AddModifyForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IDtbx = new System.Windows.Forms.TextBox();
            this.Custbx = new System.Windows.Forms.TextBox();
            this.itemsGridview = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddModifySource1 = new System.Windows.Forms.BindingSource(this.components);
            this.deleteItem = new System.Windows.Forms.Button();
            this.Modifybtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddModifySource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 444);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "orderItems";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.IDtbx);
            this.panel2.Controls.Add(this.Custbx);
            this.panel2.Controls.Add(this.itemsGridview);
            this.panel2.Location = new System.Drawing.Point(184, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 402);
            this.panel2.TabIndex = 16;
            // 
            // IDtbx
            // 
            this.IDtbx.Location = new System.Drawing.Point(3, 37);
            this.IDtbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IDtbx.Name = "IDtbx";
            this.IDtbx.Size = new System.Drawing.Size(112, 28);
            this.IDtbx.TabIndex = 5;
            this.IDtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Custbx
            // 
            this.Custbx.Location = new System.Drawing.Point(3, 102);
            this.Custbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Custbx.Name = "Custbx";
            this.Custbx.Size = new System.Drawing.Size(112, 28);
            this.Custbx.TabIndex = 6;
            // 
            // itemsGridview
            // 
            this.itemsGridview.AutoGenerateColumns = false;
            this.itemsGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.nAMEDataGridViewTextBoxColumn,
            this.prizeDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn});
            this.itemsGridview.DataSource = this.AddModifySource1;
            this.itemsGridview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemsGridview.Location = new System.Drawing.Point(0, 176);
            this.itemsGridview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.itemsGridview.Name = "itemsGridview";
            this.itemsGridview.RowHeadersWidth = 62;
            this.itemsGridview.RowTemplate.Height = 27;
            this.itemsGridview.Size = new System.Drawing.Size(662, 226);
            this.itemsGridview.TabIndex = 11;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // nAMEDataGridViewTextBoxColumn
            // 
            this.nAMEDataGridViewTextBoxColumn.DataPropertyName = "NAME";
            this.nAMEDataGridViewTextBoxColumn.HeaderText = "NAME";
            this.nAMEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nAMEDataGridViewTextBoxColumn.Name = "nAMEDataGridViewTextBoxColumn";
            this.nAMEDataGridViewTextBoxColumn.Width = 150;
            // 
            // prizeDataGridViewTextBoxColumn
            // 
            this.prizeDataGridViewTextBoxColumn.DataPropertyName = "Prize";
            this.prizeDataGridViewTextBoxColumn.HeaderText = "Prize";
            this.prizeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.prizeDataGridViewTextBoxColumn.Name = "prizeDataGridViewTextBoxColumn";
            this.prizeDataGridViewTextBoxColumn.Width = 150;
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "Num";
            this.numDataGridViewTextBoxColumn.HeaderText = "Num";
            this.numDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            this.numDataGridViewTextBoxColumn.Width = 150;
            // 
            // AddModifySource1
            // 
            this.AddModifySource1.DataMember = "OrderItems";
            this.AddModifySource1.DataSource = typeof(DatabaseOrder.Order);
            // 
            // deleteItem
            // 
            this.deleteItem.Location = new System.Drawing.Point(869, 119);
            this.deleteItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(84, 44);
            this.deleteItem.TabIndex = 14;
            this.deleteItem.Text = "删除";
            this.deleteItem.UseVisualStyleBackColor = true;
            this.deleteItem.Click += new System.EventHandler(this.deleteItem_Click);
            // 
            // Modifybtn
            // 
            this.Modifybtn.Location = new System.Drawing.Point(869, 258);
            this.Modifybtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Modifybtn.Name = "Modifybtn";
            this.Modifybtn.Size = new System.Drawing.Size(84, 37);
            this.Modifybtn.TabIndex = 13;
            this.Modifybtn.Text = "修改";
            this.Modifybtn.UseVisualStyleBackColor = true;
            this.Modifybtn.Click += new System.EventHandler(this.Modifybtn_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(869, 14);
            this.Addbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(84, 37);
            this.Addbtn.TabIndex = 12;
            this.Addbtn.Text = "增加";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.Location = new System.Drawing.Point(869, 379);
            this.Exitbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(84, 37);
            this.Exitbtn.TabIndex = 10;
            this.Exitbtn.Text = "退出";
            this.Exitbtn.UseVisualStyleBackColor = true;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // AddModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 444);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Modifybtn);
            this.Controls.Add(this.deleteItem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddModifyForm";
            this.Text = "AddModifyForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddModifySource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox IDtbx;
        private System.Windows.Forms.TextBox Custbx;
        private System.Windows.Forms.DataGridView itemsGridview;
        public System.Windows.Forms.Button Modifybtn;
        public System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.BindingSource AddModifySource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button deleteItem;
    }
}