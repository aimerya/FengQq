using System;
using System.Data;
using System.Drawing;
using OrderManage;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;


namespace OrderManageForms
{
    public partial class DeleteOrderForm : Form
    {
        public DeleteOrderForm()
        {
            InitializeComponent();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = int.Parse(txtOrderID.Text);
                bool isExisting = OrderService.DeleteOrder(orderID);    
                if (isExisting)
                {
                    MessageBox.Show("成功删除订单");
                }
                else
                {
                    MessageBox.Show("需要删除的订单不存在");
                }
            }
            catch(FormatException fe)
            {
                MessageBox.Show("输入错误！");
            }
        }
    }
}
