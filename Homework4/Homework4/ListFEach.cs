//1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。
//通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。



using System;
using System.Collections.Generic;


namespace Homework4
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class List<T>
    {
        private Node<T> head { get; set; }
        private Node<T> tail { get; set; }
        public void ForEach(Action<T> action)
        {
            for (Node<T> x = head; x != null; x = x.Next)
            {
                action(x.Data);
            }
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
    }

    class ListFEach
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int x = 0; x < 10; x++)
            {
                list.Add(x);
            }
            list.ForEach(x => Console.WriteLine(x));
            int max = 0;
            int min=0;
            int sum = 0;
            list.ForEach(s => { max = max < s ? s : max; });
            list.ForEach(s => { min = min > s ? s : min; });
            list.ForEach(delegate (int x) { sum += x; });
            Console.WriteLine("最大值为：" + max);
            Console.WriteLine("最小值为：" + min);
            Console.WriteLine("和为："+sum);
        }
    }
}
