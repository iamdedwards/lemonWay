using System.Numerics;
using System.Linq;
using NUnit.Framework;
using lemonWay;
using lemonWay.Controllers;

namespace lemonWayTest
{
	
	[TestFixture]
	public class FibonacciTests
	{
		[Test]
		public void FibonacciInvalid()
		{
			var controller = new FibonacciController();
			var error = "-1";
			Assert.AreEqual(error, controller.Get(0));
			Assert.AreEqual(error, controller.Get(-1));
			Assert.AreEqual(error, controller.Get(-2));
			Assert.AreEqual(error, controller.Get(101));
			Assert.AreEqual(error, controller.Get(102));
			Assert.AreEqual(error, controller.Get(103));
		}

		[Test]
		public void FibonnaciServiceMirrorsGenerator()
		{
			var fromGenerator = Fibonacci.Sequence(42).ElementAt(41);
			var fromService = new FibonacciController().Get(42);
		
			Assert.AreEqual(fromGenerator.ToString(), fromService);
		}
		
		[Test]
		public void Fibonacci100()
		{
			var controller = new FibonacciController();
	 		BigInteger fib100 = 3;
			fib100 *= 25;
			fib100 *= 11;
			fib100 *= 41;
			fib100 *= 101;
			fib100 *= 151;
			fib100 *= 401;
			fib100 *= 3001;
			fib100 *= 570601;
			Assert.AreEqual(fib100.ToString(), controller.Get(100));
		}
		
		[Test]
		public void FibonacciValidSample()
		{
			var controller = new FibonacciController();

			Assert.AreEqual("1", controller.Get(2));
			Assert.AreEqual("2", controller.Get(3));
			Assert.AreEqual("3", controller.Get(4));
			Assert.AreEqual("5", controller.Get(5));
			Assert.AreEqual("8", controller.Get(6));
			Assert.AreEqual("13", controller.Get(7));
			Assert.AreEqual("1597", controller.Get(17));
			Assert.AreEqual("433494437", controller.Get(43));
		}
	}
}