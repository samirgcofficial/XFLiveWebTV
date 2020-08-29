using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XamLiveVideo.Models
{
	[XmlRoot(ElementName = "video")]
	public class Video
	{
		[XmlElement(ElementName = "ref_no")]
		public string Ref_no { get; set; }
		[XmlElement(ElementName = "clip_key")]
		public string Clip_key { get; set; }
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "tags")]
		public string Tags { get; set; }
		[XmlElement(ElementName = "tag_number")]
		public string Tag_number { get; set; }
		[XmlElement(ElementName = "tag_string")]
		public string Tag_string { get; set; }
		[XmlElement(ElementName = "video_source")]
		public string Video_source { get; set; }
		[XmlElement(ElementName = "stream_name")]
		public string Stream_name { get; set; }
		[XmlElement(ElementName = "channel_ref")]
		public string Channel_ref { get; set; }
		[XmlElement(ElementName = "duration")]
		public string Duration { get; set; }
		[XmlElement(ElementName = "date_created")]
		public string Date_created { get; set; }
		[XmlElement(ElementName = "date_modified")]
		public string Date_modified { get; set; }
		[XmlElement(ElementName = "file_size")]
		public string File_size { get; set; }
	}

	[XmlRoot(ElementName = "video_list")]
	public class Video_list
	{
		[XmlElement(ElementName = "video")]
		public List<Video> Video { get; set; }
	}

	[XmlRoot(ElementName = "response")]
	public class ApiVideoResponse
	{
		[XmlElement(ElementName = "result")]
		public string Result { get; set; }
		[XmlElement(ElementName = "count")]
		public string Count { get; set; }
		[XmlElement(ElementName = "timestamp")]
		public string Timestamp { get; set; }
		[XmlElement(ElementName = "video_list")]
		public Video_list Video_list { get; set; }
	}
}
