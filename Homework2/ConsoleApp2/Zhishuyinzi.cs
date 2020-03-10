/*


using System;

//1.编写程序输出用户指定数据的所有素数因子。
namespace ConsoleApp2
{
    class Zhishuyinzi
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num;)
            {
                if (num % i == 0)
                {
                    Console.WriteLine(i + " ");
                    do
                    {
                        num /= i;
                    } while (num % i == 0);
                    
                }
                else
                {
                    i++;
                }
            }
        }
    }
}

*/