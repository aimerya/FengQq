using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculationWin
{
	public partial class CalculationWin : Form
	{
		public CalculationWin()
		{
			InitializeComponent();
		}

		
		private void CalculationWin_Load(object sender, EventArgs e)
		{

		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			double x = Convert.ToDouble(textBox1.Text);
			double y = Convert.ToDouble(textBox2.Text);
			textBox3.Text = string.Format("{0}", x + y);
		}


		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			double x = Convert.ToDouble(textBox1.Text);
			double y = Convert.ToDouble(textBox2.Text);
			textBox3.Text = string.Format("{0}", x - y);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				double x = Convert.ToDouble(textBox1.Text);
				double y = Convert.ToDouble(textBox2.Text);
				try
				{
					textBox3.Text=string.Format("{0}", x / y);
					if (y == 0)
					{
						throw new DivideByZeroException();
					}
				}catch(DivideByZeroException dze)
				{
					textBox3.Text = "除数不能为0！";
				}
			}catch(Exception ex)
			{
				textBox3.Text = ex.Message;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			double x = Convert.ToDouble(textBox1.Text);
			double y = Convert.ToDouble(textBox2.Text);
			textBox3.Text = string.Format("{0}", x * y);
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
