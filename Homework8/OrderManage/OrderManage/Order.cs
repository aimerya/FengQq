using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManage
{
    [Serializable]
    public class Order
    {
        //订单
        private int orderID;
        private string customer;
                private DateTime dateTime;
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public string Customer { get => customer; set => customer = value; }
        private string address;
        public string Address { get => address; set => address = value; }

        //金额
        public double OrderPrice
        { get {
                double sum = 0;
                foreach(OrderItem orderItem in OrderItems)
                {
                    sum += orderItem.OrderItemPrice;
                }
                return sum;
              }
        }

        //订单明细
        private List<OrderItem> orderItems = new List<OrderItem>();
        public List<OrderItem> OrderItems { get => orderItems; set => orderItems = value; }
        //初始化
        public Order() { }
        public Order(int orderID, DateTime dateTime, string customer, string address)
        {
            this.Customer = customer;
            this.Address = address;
            this.OrderID = orderID;
            this.DateTime = dateTime;
        }
        public override bool Equals(object obj) 
        {
            Order order = obj as Order;
            if (order == null)
            {
                return false;
            }
            return this.OrderID == order.OrderID;
        }

        //订单明细
        public void AddOrderItem(OrderItem orderItem) 
        {
            OrderItems.Add(orderItem);
        }

        public override string ToString()
        {
            string orderInfo;
            orderInfo = $"订单号：{this.OrderID.ToString()}," +
                $"下单日期：{this.DateTime.ToString()}," +
                $"客户姓名：{this.Customer}," +
                $"送货地址：{this.Address},";
            return orderInfo;
        }
    }
}