using System.Web.Http;
using System.Numerics;
using System.Collections.Generic;
using log4net;
using System.Linq;

namespace lemonWay.Controllers
{
	public class FibonacciController : ApiController
	{
		private static readonly IEnumerable<BigInteger> sequence = Fibonacci.Sequence(100);
        private static readonly ILog Log = LogManager.GetLogger(typeof(FibonacciController).Name);

		[HttpGet]
		public string Get(int index)
		{
			Log.Info($"|GET| query=\"index={index}\"\n");
			BigInteger value;
			if (index < 1 || index > 100)
			{
				value = -1;
				var diff = (index < 1) ? "< 1" : "> 100";
				Log.Info("|Out of range| index {diff}\n");
			}
			else
			{
				value = (FibonacciController.sequence.ElementAt(index - 1));
			}
			Log.Info($"return {value}");
			return (value.ToString());
		}
	}
}
