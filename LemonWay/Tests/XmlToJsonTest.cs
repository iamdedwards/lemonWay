using Newtonsoft.Json.Linq;
using NUnit.Framework;
using lemonWay.Controllers;

namespace lemonWayTest
{
	[TestFixture]
	public class XmlToJsonTests
	{
		[Test]
		public void XmlInvalid()
		{
			var controller = new XmlToJsonController();
			
			var invalid = "<bar>foo</foo>";
			Assert.AreEqual("Bad Xml format", controller.Get(invalid));
			invalid = "<bar *>foo</bar>";
			Assert.AreEqual("Bad Xml format", controller.Get(invalid));
			invalid = "<:bar>foo</bar>";
			Assert.AreEqual("Bad Xml format", controller.Get(invalid));
			invalid = "<bar,>foo</bar>";
			Assert.AreEqual("Bad Xml format", controller.Get(invalid));
		}
		
		[Test]
		public void ValidXmlSimple()
		{
			var controller = new XmlToJsonController();
		
			var json = controller.Get("<lemon><way>Test</way></lemon>");
			var jObj = JToken.FromObject(json);
			Assert.True(jObj.HasValues);
			Assert.DoesNotThrow(() => { var getVal = jObj["lemon"]; });
			Assert.NotNull(jObj["lemon"]);
			Assert.DoesNotThrow(() => { var getVal = jObj["lemon"]["way"]; });
			Assert.AreEqual(jObj["lemon"]["way"].ToString(), "Test");
		}
		
		[Test]
		public void AutoClosingProperty()
		{
			var controller = new XmlToJsonController();
			var json = controller.Get("<auto><closing><property /></closing></auto>");
			var jObj = JObject.Parse(json.ToString());
			Assert.True(jObj["auto"]["closing"].HasValues);
		}
	
		[Test]
		public void ValidXmlLong()
		{
			var controller = new XmlToJsonController();
			var xml = @"
					<TRANS>
						<HPAY>
							<ID>103</ID>
							<STATUS>3</STATUS>
							<EXTRA>
								<IS3DS>0</IS3DS>
								<AUTH>031183</AUTH>
							</EXTRA>
							<INT_MSG/>
							<MLABEL>501767XXXXXX6700</MLABEL>
							<MTOKEN>project01</MTOKEN>
						</HPAY>
					</TRANS>";
	
			var Obj = controller.Get(xml);
			var jObj = JObject.Parse(Obj.ToString());
			var hpay = jObj["TRANS"]["HPAY"];
			Assert.NotNull(hpay);
			Assert.NotNull(hpay["ID"]);
			Assert.AreEqual(hpay["ID"].ToString(), "103");
			Assert.AreEqual(hpay["EXTRA"]["AUTH"].ToString(), "031183");
			Assert.AreEqual(hpay["STATUS"].ToString(), "3");
		}
	}
}