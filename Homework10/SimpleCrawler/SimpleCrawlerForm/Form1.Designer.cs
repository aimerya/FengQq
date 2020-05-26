namespace SimpleCrawlerForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvUrls = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsUrls = new System.Windows.Forms.BindingSource(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.txtStartUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUrls)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUrls
            // 
            this.dgvUrls.AutoGenerateColumns = false;
            this.dgvUrls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Url,
            this.Status});
            this.dgvUrls.DataSource = this.bdsUrls;
            this.dgvUrls.Location = new System.Drawing.Point(18, 168);
            this.dgvUrls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUrls.Name = "dgvUrls";
            this.dgvUrls.RowHeadersWidth = 62;
            this.dgvUrls.RowTemplate.Height = 23;
            this.dgvUrls.Size = new System.Drawing.Size(1164, 489);
            this.dgvUrls.TabIndex = 0;
            // 
            // Index
            // 
            this.Index.DataPropertyName = "Index";
            this.Index.HeaderText = "序号";
            this.Index.MinimumWidth = 8;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 150;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "URL";
            this.Url.HeaderText = "网址";
            this.Url.MinimumWidth = 8;
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 400;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(625, 63);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始爬取";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtStartUrl
            // 
            this.txtStartUrl.Location = new System.Drawing.Point(142, 69);
            this.txtStartUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStartUrl.Name = "txtStartUrl";
            this.txtStartUrl.Size = new System.Drawing.Size(394, 28);
            this.txtStartUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "起始网页";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(18, 126);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 18);
            this.lblInfo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 465);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartUrl);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgvUrls);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "SimpleCrawler";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUrls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrls;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtStartUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsUrls;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

