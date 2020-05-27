using OrderManage;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManageForms
{
    public partial class AddOrderForm : Form
    {
        public AddOrderForm()
        {
            InitializeComponent();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = int.Parse(txtOrderID.Text);          
                DateTime dateTime = DateTime.Parse(txtDate.Text);  
                string customer = txtCustomerName.Text;                
                string address = txtAddress.Text;                   

                Order newOrder = new Order(orderID, dateTime, customer, address);     

                bool isSame = false;       
                foreach (Order order in OrderService.orders)        
                {
                    if (newOrder == order)
                        isSame = true;
                }
                if (!isSame)              
                {
                    OrderService.AddOrder(newOrder);
                    OrderService.SortedByOrderID();
                    MessageBox.Show("成功创建订单");
                }
                else                     
                {
                    MessageBox.Show("订单已存在！");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("错误：输入不正确,请重新输入！");
            }
        }

        private void btnAddOrderItem_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = int.Parse(txtOrderItemID.Text);       
                string orderItemName = txtItem.Text;                 
                double unitOrderPrice = double.Parse(txtUnitItemPrice.Text);      
                int count = int.Parse(txtCount.Text);                             

                OrderItem newOrderItem = new OrderItem(orderItemName, unitOrderPrice, count);  

                bool isHavingOrder = false;
                bool isHavingSameOrderItem = false;                  
                foreach (Order order in OrderService.orders)        
                {
                    if (orderID == order.OrderID)       
                    {
                        isHavingOrder = true;
                        foreach (OrderItem orderItem in order.OrderItems) 
                        {
                            if (newOrderItem.Equals(orderItem))    
                                isHavingSameOrderItem = true;
                        }
                        if (!isHavingSameOrderItem)        
                        {
                            OrderService.AddOrderItem(order, newOrderItem);
                            MessageBox.Show("成功添加订单明细");
                        }
                        else                                       
                            MessageBox.Show("错误：订单明细已存在！");
                    }
                }
                if (!isHavingOrder)
                    MessageBox.Show("错误：订单不存在！");
            }
            catch(FormatException fe)
            {
                MessageBox.Show("错误：输入不正确,请重新输入！");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
