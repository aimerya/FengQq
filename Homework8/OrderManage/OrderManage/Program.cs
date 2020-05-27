using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManage
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Run = true;

            while (Run)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("1.添加订单     2.修改订单     3.删除订单     4.查询订单     5.导入订单     6.导出订单     7.退出程序");
                Console.Write("请选择：");
                string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        //创建新订单及新订单的订单详细
                        Console.Write("请输入订单号：");                   
                        int newOrderID = int.Parse(Console.ReadLine());
                        Console.Write("请输入客户名字：");
                        string newCustomer = Console.ReadLine();
                        Console.Write("请输入送货地址：");
                        string newAddress = Console.ReadLine();
                        Order newOrder = new Order(newOrderID, 
                            DateTime.Now, newCustomer, newAddress);  
                        bool isSameOrder = false;    
                        foreach (Order order in OrderService.orders) 
                        {
                            if (newOrder == order)
                                isSameOrder = true;
                        }
                        if (!isSameOrder)                      
                        {
                            OrderService.AddOrder(newOrder);
                            OrderService.SortedByOrderID();
                        }
                        else                 
                            Console.WriteLine("订单已存在");
                        //为新订单添加订单明细
                        bool addOrderItemIsOver = false;                    
                        while (!addOrderItemIsOver)
                        {
                            Console.WriteLine("-------添加订单明细-------");
                            Console.Write("请输入货物名称：");
                            string newOrderItemName = Console.ReadLine();
                            Console.Write("请输入货物单价：");
                            int newUnitOrderItemPrice = int.Parse(Console.ReadLine());
                            Console.Write("请输入货物数量：");
                            int newCount = int.Parse(Console.ReadLine());
                            OrderItem newOrderItem = new OrderItem(newOrderItemName,
                                newUnitOrderItemPrice, newCount);
                            bool isHavingSameOrderItem = false;                    
                            foreach (OrderItem orderItem in newOrder.OrderItems)    
                            {
                                if (newOrderItem.Equals(orderItem))
                                    isHavingSameOrderItem = true;
                            }
                            if (!isHavingSameOrderItem)   
                            {
                                OrderService.AddOrderItem(newOrder, newOrderItem);
                            }
                            else 
                            {
                                Console.WriteLine("订单明细已存在");
                            }                             
                            Console.Write("是否结束添加订单？（是：Y，否：N）");    
                            string temp = Console.ReadLine();
                            if (temp == "Y")
                                addOrderItemIsOver = true;
                            OrderService.Export();
                        }
                        break;
                    case "2":
                        try
                        {
                            //提示用户输入修改后的信息
                            Console.Write("请输入需要修改订单的订单号：");
                            int modifyOrderID = int.Parse(Console.ReadLine());
                            Console.Write("请输入修改后的客户名字：");
                            string modifiedCustomer = Console.ReadLine();
                            Console.Write("请输入修改后的送货地址：");
                            string modifiedAddress = Console.ReadLine();
                            bool modifyOrderIsOk = OrderService.ModifyOrder(modifyOrderID,
                                modifiedCustomer,modifiedAddress); 
                            if (!modifyOrderIsOk)                                  
                                throw new OrderServiceException("需要修改的订单不存在！");
                        }
                        catch (OrderServiceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("请输入需要删除订单的订单号：");
                            int deleteOrderID = int.Parse(Console.ReadLine());
                            bool deleteOrderIsOk = OrderService.DeleteOrder(deleteOrderID);   
                            if (!deleteOrderIsOk)                                          
                                throw new OrderServiceException("错误：需要删除的订单不存在！");
                        }
                        catch (OrderServiceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("--------查询订单--------");
                            Console.WriteLine("1.按订单号查询      2.按货物名查询      3.按客户名查询");
                            Console.Write("请选择：");
                            string selectEnquiry = Console.ReadLine();
                            //标志是否成功查询
                            bool enquiryIsOk;          
                            switch (selectEnquiry)
                            {
                                case "1":                                              
                                    Console.Write("请输入订单号：");
                                    int enquiryID = int.Parse(Console.ReadLine());
                                    Order enquiriedOrderByID;
                                    enquiryIsOk = OrderService.EnquiryOrder(enquiryID, out enquiriedOrderByID);
                                    if (enquiryIsOk)                       
                                    {
                                        Console.WriteLine(enquiriedOrderByID.ToString());   
                                        foreach (OrderItem orderItem in enquiriedOrderByID.OrderItems)
                                            Console.WriteLine(orderItem.ToString());    
                                    }
                                    else
                                        throw new OrderServiceException("订单不存在");
                                    break;

                                case "2":                                        
                                    Console.Write("请输入货物名：");
                                    string enquiryItemName = Console.ReadLine();
                                    List<Order> enquiryOrdersByItem = OrderService.
                                        EnquiryOrderByItem(enquiryItemName, out enquiryIsOk);
                                    if (enquiryIsOk)
                                    {
                                        enquiryOrdersByItem.Sort((o1, o2) => (int)((o1.OrderPrice - o2.OrderPrice) * 100)); 
                                        foreach (Order order in enquiryOrdersByItem)
                                        {
                                            Console.WriteLine(order.ToString());
                                            foreach (OrderItem orderItem in order.OrderItems)
                                                Console.WriteLine(orderItem.ToString());
                                        }
                                    }
                                    else
                                        throw new OrderServiceException("订单不存在");
                                    break;

                                case "3":                                            
                                    Console.Write("请输入客户名:");
                                    string enquiryCustomer = Console.ReadLine();
                                    List<Order> enquiryOrdersByCustomer = new List<Order>();
                                    enquiryOrdersByCustomer = OrderService.EnquiryOrderByCustomer
                                        (enquiryCustomer, out enquiryIsOk);
                                    if (enquiryIsOk)
                                    {
                                        foreach (Order order in enquiryOrdersByCustomer)
                                        {
                                            Console.WriteLine(order.ToString());
                                            foreach (OrderItem orderItem in order.OrderItems)
                                                Console.WriteLine(orderItem.ToString());
                                        }
                                    }
                                    else
                                        throw new OrderServiceException("订单不存在");
                                    break;
                            }
                        }
                        catch (OrderServiceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "5":
                        OrderService.Import();
                        break;
                    case "6":
                        OrderService.Export();
                        break;
                    case "7":
                        Run = false;
                        break;
                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }
        }
    }
}
