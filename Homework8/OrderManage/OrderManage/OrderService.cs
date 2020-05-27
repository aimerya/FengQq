using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading.Tasks;


namespace OrderManage
{
    [Serializable]
    public class OrderService
    {
        public static List<Order> orders = new List<Order>();

        public static void AddOrderItem(Order order, OrderItem newOrderItem)
        {
                order.OrderItems.Add(newOrderItem);
        }

        public static void AddOrder(Order newOrder)
        {
                orders.Add(newOrder);
        }

        public static bool DeleteOrder(int oldOrderID)
        {
            foreach(Order order in orders)
            {
                if (oldOrderID == order.OrderID)
                {
                    orders.Remove(order);
                    return true;
                }
            }
            return false;
        }

        public static bool ModifyOrder(int oldOrderID,string customer,string address)
        {
            for (int i = 0; i < orders.Count(); i++)
            {
                if (orders[i].OrderID == oldOrderID)
                {
                    orders[i].Customer = customer;
                    orders[i].Address = address;
                    return true;
                }
            }
            return false;
        }

        //查询
        //按订单号查询订单
        public static bool EnquiryOrder(int orderID,out Order enquiriedOrder)                 
        {
            enquiriedOrder = null;
            foreach (Order order in orders)
            {
                if (order.OrderID == orderID)
                {
                    enquiriedOrder = order;
                    return true;
                }
            }
            return false;
        }
        //按货物名查询
        public static List<Order> EnquiryOrderByItem(string item, out bool isReady)                
        {
            List<Order> enquiryOrders = new List<Order>();
            isReady = false;
            foreach (Order order in orders)
            {
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    if (orderItem.Item == item)
                    {
                        enquiryOrders.Add(order);
                        isReady = true;
                    }
                }
            }
            return enquiryOrders;
        }

        //按客户名查询
        public static List<Order> EnquiryOrderByCustomer(string customer,out bool isReady)        
        {
            var selectedOrders = orders.Where(o => o.Customer == customer).OrderBy(o => o.OrderPrice);
            if (selectedOrders != null)
            {
                isReady = true;
                return selectedOrders.ToList<Order>();
            }
            else
            {
                isReady = false;
                return null;
            }
        }

        //按订单号排序
        public static void SortedByOrderID()          
        {
            orders.Sort((o1,o2)=>o1.OrderID-o2.OrderID);
        }

                //上传订单
        public static void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using(FileStream fs= new FileStream("orders.xml", FileMode.Open))
            {
                orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }

        public static void Import(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }

        public static void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using(FileStream fs= new FileStream("orders.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orders);
            }
        }
    }
    public class OrderServiceException : ApplicationException
    {
        public OrderServiceException(string message) : base(message)
        {
        }
    }
}