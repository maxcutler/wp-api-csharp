using Newtonsoft.Json;

namespace PortableWordPressApi.Resources
{
	public class Media : Post
	{
		public new Post Parent { get; set; }

		public string Source { get; set; }

		[JsonProperty("is_image")]
		public bool IsImage { get; set; }

		[JsonProperty("attachment_meta")]
		public MediaMeta AttachmentMeta { get; set; }
	}
}
