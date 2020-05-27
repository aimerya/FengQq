using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManage
{
    [Serializable]
    public class OrderItem
    {
        //货物名
        private string item;
        public string Item { get => item; set => item = value; }
        //数量
        private int count;
        public int Count { get => count; set => count = value; }
        //单价
        private double unitOrderItemPrice;
        public double UnitOrderItemPrice { get => unitOrderItemPrice; set => unitOrderItemPrice = value; }
        //明细
        public double OrderItemPrice { get { return UnitOrderItemPrice * Count; } }

        //初始化
        public OrderItem() { }
        public OrderItem(string item, double unitOrderItemPrice, int count)
        {
            this.Item = item;
            this.UnitOrderItemPrice = unitOrderItemPrice;
            this.Count = count;
        }

        public override string ToString()
        {
            string orderItemInfo;
            orderItemInfo = $"货物名称：{this.Item}," +
                $"货物单价：{this.UnitOrderItemPrice.ToString()}," +
                $"货物数量：{this.Count.ToString()}," +
                $"货物总金额：{this.OrderItemPrice.ToString()}";
            return orderItemInfo;
        }

        public override bool Equals(object obj)
        {
            OrderItem orderItem = obj as OrderItem;
            if (orderItem == null)
            {
                return false;
            }
            return this.Item == orderItem.Item;
        }

    }
}