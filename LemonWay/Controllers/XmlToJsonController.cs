using System;
using System.Web.Http;
using System.Xml.Linq;
using log4net;
using Newtonsoft.Json.Linq;

namespace lemonWay.Controllers
{
	public class XmlToJsonController : ApiController
	{
        private static readonly ILog Log = LogManager.GetLogger(typeof(XmlToJsonController).Name);
		
		[HttpGet]
		public object Get(string xmlString)
		{
			Log.Info($"|GET| query=\"xmlString={xmlString}\"\n");
			XDocument xml = null;
			try 
			{
				xml = XDocument.Parse(xmlString);
			}
			catch (Exception e)
			{
			
				Log.Warn(e.GetBaseException());
				return ("Bad Xml format");
			}
			var ret = JObject.FromObject(xml);
			Log.Info($"return {ret}");
			return (ret);
		}
	}
}