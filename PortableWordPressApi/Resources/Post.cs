using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PortableWordPressApi.Resources
{
	public class Post
	{
		public string ID { get; set; }

		public string Title { get; set; }

		[JsonProperty("date_gmt")]
		public DateTime DateGmt { get; set; }

		[JsonProperty("modified_gmt")]
		public DateTime ModifiedGmt { get; set; }

		public string Status { get; set; }

		public string Type { get; set; }

		public string Name { get; set; }

		public User Author { get; set; }

		public string Password { get; set; }

		public string Content { get; set; }

		public string Excerpt { get; set; }

		public string Parent { get; set; }

		public string Link { get; set; }

		public string Guid { get; set; }

		[JsonProperty("menu_order")]
		public int MenuOrder { get; set; }

		[JsonProperty("comment_status")]
		public string CommentStatus { get; set; }

		[JsonProperty("ping_status")]
		public string PingStatus { get; set; }

		public bool Sticky { get; set; }

		// thumbnail

		[JsonProperty("post_format")]
		public string PostFormat { get; set; }

		[JsonProperty("post_meta")]
		public PostMeta PostMeta { get; set; }

		public Dictionary<string, List<Term>> Terms { get; set; }

		public Meta Meta { get; set; }
	}
}
