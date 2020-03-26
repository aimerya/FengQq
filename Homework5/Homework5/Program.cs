/*
 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、
     查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），
   订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。
       默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5
{
    class Program
    {
        public static void Main(String[] args)
        {
            OrderService orderService = new OrderService();
            while (true)
            {
                Console.WriteLine("输入1添加订单,输入2查询订单,输入3修改订单,输入4删除订单,输入5显示全部订单,输入6将订单按订单号排序,输入0退出");
                int flag = int.TryParse(Console.ReadLine(), out flag) ? flag : 0;
                switch (flag)
                {
                    case 1:
                        Order order = new Order();
                        orderService.insert(order);
                        break;
                    case 2:
                        orderService.search();
                        break;
                    case 3:
                        Console.WriteLine("输入要修改的订单号");
                        string str = Console.ReadLine();
                        Console.WriteLine("输入修改后的订单");
                        Order order1 = new Order();
                        orderService.change(str, order1);
                        break;
                    case 4:
                        Console.WriteLine("输入要删除的订单号");
                        string str2 = Console.ReadLine();
                        orderService.delete(str2);
                        break;
                    case 5:
                        orderService.show();
                        break;
                    case 6:
                        orderService.sort();
                        Console.WriteLine("订单排序完成");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("输入字符无效\n");
                        break;
                }
                if (flag == 0)
                {
                    break;
                }
            }
        }
    }

    class Order : IComparable{
        public string orderNumber;
        public string clientName;
        public double totalPrice;
        public List<OrderItem> orderList;
        private static int hash = 0;
        private readonly int hashCode;

        public Order(){
            Console.WriteLine("输入订单号");
            orderNumber = Console.ReadLine();
            Console.WriteLine("输入客户名");
            clientName = Console.ReadLine();
            double db= 0;
            double d;
            orderList = new List<OrderItem>();
            while (true){
                Console.WriteLine("请先输入货物名称，回车后输入货物总价,输入end结束");
                string name = Console.ReadLine();
                if (name == "end"){
                    break;
                }         
                bool b = double.TryParse(Console.ReadLine(), out d);
                while (!b){
                    Console.WriteLine("输入金额必须是数字");
                    b = double.TryParse(Console.ReadLine(), out d);
                }
                db += d;
                bool bl = false;
                for (int i = 0; i < orderList.Count; i++){
                    if (orderList[i].ItemName == name){
                        Console.WriteLine("订单中已有该商品");
                        orderList[i].ItemPrice += d;
                        bl = true;
                        break;
                    }
                }
                if (bl){
                    continue;
                }
                orderList.Add(new OrderItem(name, d));
            }
            totalPrice = db;
            orderList.Sort();
            hashCode = hash++;
        }

      

        override public string ToString(){
            string st;
            st = "客户名：" + clientName + "\n";
            st += "订单号： " + orderNumber + "\n";
            st += "订单总价： " + totalPrice.ToString() + "\n";
            st += "订单明细：\n";

            foreach (OrderItem oi in orderList){
                st += "商品名称:" + oi.ItemName + "  ";
                st += "商品总价 " + oi.ItemPrice + "\n";
            }
            return st;
        }

        override public int GetHashCode(){
            return hashCode;
        }

        public bool contain(string cargoName){
            var v = from o in orderList where o.ItemName == cargoName select o;
            return v.Count() > 0;
        }

        public override bool Equals(object obj){
            return this.ToString() == obj.ToString();
        }

        public int CompareTo(object obj){
            Order order = (Order)obj;
            if (order == null){
                return 1;
            }
            return string.Compare(this.orderNumber, order.orderNumber);
        }
    }

    class OrderItem : IComparable{
        public string ItemName;
        public double ItemPrice;

        public OrderItem(string name, double amount){
            ItemName = name;
            ItemPrice = amount;
        }

        public int CompareTo(object obj2){
            OrderItem orderItem = (OrderItem)obj2;
            if (orderItem == null){
                return 1;
            }
            return string.Compare(this.ItemName, orderItem.ItemName);
        }
    }

    class OrderService{
        private List<Order> orders;
        public OrderService(){
            orders = new List<Order>();
        }

        public void insert(Order order){
            foreach (Order o in orders){
                if (o.orderNumber == order.orderNumber){
                    Console.WriteLine("存在相同的订单，添加失败\n");
                    return;
                }
            }
            orders.Add(order);
            Console.WriteLine("添加订单成功\n");
        }

        public void change(string former, Order fresh){
            for (int i = 0; i < orders.Count; i++){
                if (orders[i].orderNumber == former){
                    orders[i] = fresh;
                    Console.WriteLine("订单修改成功\n");
                    return;
                }
            }
            Console.WriteLine("未找到该订单，修改失败\n");
        }

        public void sort(){
            orders.Sort();
        }

        public void search(){
            while (true){
                Console.WriteLine("输入1按订单号查询，输入2按客户名查询,输入3按商品名称查询,输入9退出查询");
                int f = int.TryParse(Console.ReadLine(), out f) ? f : 0;
                switch (f){
                    case 1:
                        Console.WriteLine("输入要查询的订单号");
                        string s = Console.ReadLine();
                        var v = from n in orders where n.orderNumber == s select n;
                        if (v.Count() == 0){
                            Console.WriteLine("未找到结果");
                        }
                        else{
                            foreach (Order order in v){
                                Console.WriteLine(order);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("输入要查询的客户名");
                        string str2 = Console.ReadLine();
                        var v2 = from n in orders where n.clientName == str2 select n;
                        if (v2.Count() == 0){
                            Console.WriteLine("未找到结果");
                        }
                        else{
                            foreach (Order order in v2){
                                Console.WriteLine(order);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("输入要查询的商品名");
                        string str3 = Console.ReadLine();
                        var v3 = from n in orders where n.contain(str3) select n;
                        if (v3.Count() == 0){
                            Console.WriteLine("未找到结果");
                        }
                        else{
                            foreach (Order order in v3){
                                Console.WriteLine(order);
                            }
                        }
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("输入错误，重新输入");
                        break;
                }
                if (f == 9){
                    break;
                }
            }
        }

        public void delete(string number){
            for (int i = 0; i < orders.Count; i++){
                if (orders[i].orderNumber == number){
                    orders.RemoveAt(i);
                    Console.WriteLine("删除订单成功\n");
                    return;
                }
            }
            Console.WriteLine("未找到该订单，删除失败\n");
        }

        public void show(){
            foreach (Order order in orders){
                Console.WriteLine(order);
            }
        }
    }
}
