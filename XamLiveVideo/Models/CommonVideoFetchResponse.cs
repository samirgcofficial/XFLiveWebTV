using System;
using System.Xml.Serialization;

namespace XamLiveVideo.Models
{
	[XmlRoot(ElementName = "response")]
	public class CommonVideoFetchResponse
	{
		[XmlElement(ElementName = "result")]
		public string Result { get; set; }
		[XmlElement(ElementName = "video_url")]
		public string Video_url { get; set; }
	}
}
