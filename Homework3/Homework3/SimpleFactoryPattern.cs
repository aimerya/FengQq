//1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 
//请尝试合理使用接口来实现。
//2. 随机创建10个形状对象，计算这些对象的面积之和。尝试使用简单工厂设计模式来创建对象。


using System;

namespace Homework3
{
	//接口实现
	public interface Shape
	{
		abstract public double Area { get; }
		abstract public bool IsShape();
	}

	//长方形
	class Rectangle : Shape
	{
		private double width;
		private double height;
		public Rectangle(double a,double b)
		{
			width = a;
			height = b;
		}
		public bool IsShape()
		{
			if (width > 0 && height > 0)
			{
				return true;
			}
			else
			{
				throw new ArgumentException("Invalid Shape");
			}
		}
		public double Area
		{
			get
			{
				return width * height;
			}
		}
	}

	//正方形
	class Square : Shape
	{
		private double width;
		public Square(double a)
		{
			width = a;
		}
		public bool IsShape()
		{
			if (width > 0)
			{
				return true;
			}
			else
			{
				throw new ArgumentException("Invalid Shape");
			}
		}
		public double Area
		{
			get
			{
				return width * width;
			}
		}
	}


	//三角形
	class Triangle : Shape
	{
		private double width, height;
		public Triangle (double s,double h)
		{
			width = s;
			height = h;
		}
		public bool IsShape()
		{
			if (width > 0 && height > 0)
			{
				return true;
			}
			else
			{
				throw new ArgumentException("Invalid Shape");
			}
		}
		public double Area
		{
			get
			{
				return width * height / 2;
			}
		}
	}

	//工厂
	class Factory
	{
		internal Shape Manufacture(int i)
		{
			Random ran = new Random();
			switch (i)
			{
				case 0:
					Console.WriteLine("创建了一个长方形");
					return new Rectangle(ran.NextDouble() * (100 - 0.1) + 0.1, ran.NextDouble() * (100 - 0.1) + 0.1);

				case 1:
					Console.WriteLine("创建了一个正方形");
					return new Square(ran.NextDouble() * (100 - 0.1) + 0.1);

				case 2:
					Console.WriteLine("创建了一个三角形");
					return new Triangle(ran.NextDouble() * (100 - 0.1) + 0.1, ran.NextDouble() * (100 - 0.1) + 0.1);

				default:
					return null;
			}
		}
	}

	//简单工厂模式
	public class SimpleFactoryPattern
	{
		static void Main(string[] args)
		{
			try
			{
				double sum = 0;
				double are = 0;
				for (int i = 0; i < 10; i++)
				{
					Random rd = new Random();
					int n = rd.Next(0,3);
					Factory f = new Factory();
					are= f.Manufacture(n).Area;
					sum += are;
					Console.WriteLine("它的面积是："+are);
				}
				Console.WriteLine("总面积"+sum);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ReadLine();
			}
		}
	}
}


