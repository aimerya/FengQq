/*


using System;
using System.Collections.Generic;
using System.Text;

//.编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和。
namespace ConsoleApp2
{
	class Shuzu
	{
		static void Main(string[] args)
		{
			try
			{
				int sum = 0;
				double aver = 0;
				Console.WriteLine("请输入数组长度");
				int leng = int.Parse(Console.ReadLine());
				int[] arr = new int[leng];
				Console.WriteLine("请依次输入数字：");
				for (int i = 0; i < arr.Length; i++)
				{
					arr[i] = int.Parse(Console.ReadLine());
				}
				//开始
				int max = arr[0], min = arr[0];
				for (int i = 0; i < arr.Length; i++)
				{
					sum += arr[i];
					if (arr[i] > max)
					{
						max = arr[i];
					}
					if (arr[i] < min)
					{
						min = arr[i];
					}
				}
				aver = (double)sum / arr.Length ;
				Console.WriteLine("最大值:" + max + "  " +
					"最小值:" + min + "  " +
					"平均值:" + aver + "  " +
					"所有数组元素的和:" + sum);
			}
			catch (FormatException  e)
			{
				Console.WriteLine("不是整数");
			}
		}
	}
}



*/