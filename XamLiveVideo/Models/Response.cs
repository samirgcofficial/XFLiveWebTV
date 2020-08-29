using System;
using System.Xml.Serialization;

namespace XamLiveVideo.Models
{
	[XmlRoot(ElementName = "response")]
	public class Response
	{
		[XmlElement(ElementName = "result")]
		public string Result { get; set; }
		[XmlElement(ElementName = "auth_token")]
		public string Auth_token { get; set; }
	}
}
