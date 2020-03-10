using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1
{
	class Calculation
	{
		static void Main(String[] args)
		{
			try
			{
				Console.WriteLine("请输入第一个数字：");
				double a = double.Parse(Console.ReadLine());
				Console.WriteLine("请输入第二个数字：");
				double b = double.Parse(Console.ReadLine());
				Console.WriteLine("请输入运算符（+、-、*、/）：");
				string str = Console.ReadLine();
				while(true)
				{
					switch (str)
					{
						case "+":
							Console.WriteLine(a + b);
							return;
						case "-":
							Console.WriteLine(a - b);
							return;
						case "*":
							Console.WriteLine(a * b);
							return;
						case "/":
							if (b != 0)
							{
								Console.WriteLine(a / b);
							}
							else
							{
								Console.WriteLine("除数不能为0！");
							}
							return;
						default:
							Console.WriteLine("请输入正确的符号！");
							str = Console.ReadLine();
							break;

					}
				}


			}catch(FormatException e)
			{
				Console.WriteLine("输入格式错误!");
			}

			
		}
	}
}

