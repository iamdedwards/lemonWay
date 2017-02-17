using System;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;
using System.Numerics;

namespace lemonWay
{
	public class LemonWayApp : IDisposable
	{
		private readonly IDisposable 	owinHost;
		private readonly HttpClient	 	client;
		private readonly string 		baseAddress;
		private readonly string			apiName;
		private readonly string			fibonnacciServiceName;
		private readonly string			xmlToJsonServiceName;
		
		public class Startup
		{
			public void Configuration(IAppBuilder app)
			{
				var settings = new HttpConfiguration();
				settings.Routes.MapHttpRoute(
					name: "default",
					routeTemplate : "lemonWay/{controller}/{id}",
					defaults: new {id = RouteParameter.Optional }
				);
				app.UseWebApi(settings);
			}
		}
		
		public LemonWayApp(string baseAddress)
		{
			log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
			this.owinHost = WebApp.Start<Startup>(baseAddress);
			this.apiName = "lemonWay";
			this.baseAddress = baseAddress;
			this.fibonnacciServiceName = setServiceName("fibonacci");
			this.xmlToJsonServiceName = setServiceName("xmlToJson");
			this.client = new HttpClient();
		}

		private string setServiceName(string serviceName)
		{
			return String.Join("/", baseAddress, apiName, serviceName);
		}
		
		private T getContent<T>(string address)
		{
			var response = client.GetAsync(address).Result;
			var content = response.Content.ReadAsAsync<T>().Result;
			return (content);
		}
		
		public BigInteger Fibonacci(int index)
		{
			var query = new HttpValueCollection();
			query[nameof(index)] = index.ToString();
			var address = this.fibonnacciServiceName + query.ToString();
			
			var content = getContent<int>(address);
			return (content);
		}
		
		public string XmlToJson(string xmlString)
		{
			var query = new HttpValueCollection();
			query[nameof(xmlString)] = xmlString;
			var address = this.xmlToJsonServiceName + query.ToString();
			var content = getContent<string>(address);
			return (content);
		}

		public void Dispose()
		{
			owinHost.Dispose();
		}
	}
}
