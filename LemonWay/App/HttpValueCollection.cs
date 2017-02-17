using System;
using System.Collections.Generic;

namespace lemonWay
{
	public class HttpValueCollection : Dictionary<string, object>
	{
		private string stringify;
		public HttpValueCollection()
		{
			stringify = "?";
		}
		
		private void addToQueryString(string key, object value)
		{
			if (stringify != "?")
				stringify += "&";
			stringify += $"{key}={value}";
		}

		public new void Add(string key, object value)
		{
			addToQueryString(key, value);
			base.Add(key, value);
		}
			
		public override string ToString()
		{
			if (stringify == "?")
				return ("");
			return stringify;
		}
		
		public new object this[string key]
		{
			get
			{
				return base[key];
			}
			set
			{
				addToQueryString(key, value);
				base[key] = value;
			}
		}
	}
}
