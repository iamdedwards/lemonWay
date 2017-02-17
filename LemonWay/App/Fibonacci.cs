using System.Collections.Generic;
using System.Numerics;

namespace lemonWay
{
	public static class Fibonacci
	{
		public static IEnumerable<BigInteger> Sequence(uint limit)
		{
			int position = 1;
			while (position <= limit)
			{
				BigInteger a = 0;
				BigInteger b = a + 1;
				int count = position;
				while (count > 0)
				{
					BigInteger tmp = a;
					a = b;
					b = tmp + b;
					count--;
				}
				position++;
				yield return (a);
			}
		}
	}
}
