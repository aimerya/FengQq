﻿namespace CalculationWin
{
	partial class CalculationWin
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.label1.AllowDrop = true;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(420, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(165, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = "计算器";
			this.label1.UseCompatibleTextRendering = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(159, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 33);
			this.label2.TabIndex = 1;
			this.label2.Text = "第一个数";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(744, 146);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(143, 33);
			this.label3.TabIndex = 2;
			this.label3.Text = "第二个数";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(124, 202);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(197, 28);
			this.textBox1.TabIndex = 3;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(706, 202);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(192, 28);
			this.textBox2.TabIndex = 4;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Info;
			this.button1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.Location = new System.Drawing.Point(476, 147);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(62, 42);
			this.button1.TabIndex = 5;
			this.button1.Text = "+";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(526, 476);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(126, 28);
			this.textBox3.TabIndex = 6;
			this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(357, 474);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(163, 30);
			this.label4.TabIndex = 7;
			this.label4.Text = "计算结果：";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.Info;
			this.button2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button2.Location = new System.Drawing.Point(476, 211);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(62, 42);
			this.button2.TabIndex = 8;
			this.button2.Text = "-";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.Info;
			this.button3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button3.Location = new System.Drawing.Point(476, 282);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(62, 42);
			this.button3.TabIndex = 9;
			this.button3.Text = "*";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.SystemColors.Info;
			this.button4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button4.Location = new System.Drawing.Point(476, 356);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(62, 40);
			this.button4.TabIndex = 10;
			this.button4.Text = "/";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// CalculationWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 610);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "CalculationWin";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.CalculationWin_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}

