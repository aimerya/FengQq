/*

using System;
using System.Collections.Generic;
using System.Text;
//用“埃氏筛法”求2~ 100以内的素数。
//2~ 100以内的数，先去掉2的倍数，再去掉3的倍数

namespace ConsoleApp2
{
	class Aishishaifa
	{
		static void Main(string[] args)
		{
			try
			{
				bool[] num = new bool[101];
				num[0] = num[1] = false;
				for (int i = 2; i < num.Length; i++)
				{
					num[i] = true;
				}
				//2
				int flag = 2;
				while (flag < num.Length)
				{
					for (int i = flag + 1; i < num.Length; i++)
					{

						if (num[i] && i % flag == 0)
						{
							num[i] = false;
						}
					}
					do
					{
						flag++;
					} while (flag < num.Length - 1 && !num[flag]);
				}

				for (int a = 2; a < num.Length; a++)
				{
					if (num[a])
					{
						Console.WriteLine(a + "  ");
					}
				}
				Console.Read();
			}
			catch(IndexOutOfRangeException e)
			{
				Console.WriteLine("Index was outside the bounds of the array");
				Console.Read();
			}
		}

	}
}


*/