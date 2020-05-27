using System;
using System.Linq;
using System.Text;
using System.Data;
using OrderManage;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace OrderManageForms
{
    public partial class ModifyOrderForm : Form
    {
        public ModifyOrderForm()
        {
            InitializeComponent();
        }

        private void btnModifyOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int modifyOrderID = int.Parse(txtOrderID.Text);
                string modifyCustomerName = txtModifyCustomerName.Text;
                string modifyAddress = txtModifyAddress.Text;

                bool isOK = OrderService.ModifyOrder(modifyOrderID,      
                    modifyCustomerName,modifyAddress);
                if (isOK)
                {
                    MessageBox.Show("订单修改成功");
                }
                else
                {
                    MessageBox.Show("需要修改的订单不存在");
                }
            }
            catch(FormatException fe)
            {
                MessageBox.Show("输入错误");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
