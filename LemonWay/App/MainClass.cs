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
				Console.WriteLine("tapez sur 'q' pour quitter le programme");
				char key = '0';
				while (key != 'q')
				{
					key = Console.ReadKey().KeyChar;
				}
			}
		}
	}
}