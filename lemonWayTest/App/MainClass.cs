using System;

namespace lemonWay
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			string baseAddress = "http://localhost:9000/";
			using (var app = new LemonWayApp(baseAddress))
			{
				Console.WriteLine(app.Fibonacci(10));
			}
		}
	}
}