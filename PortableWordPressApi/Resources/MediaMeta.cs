using System.Collections.Generic;
using Newtonsoft.Json;

namespace PortableWordPressApi.Resources
{
	public class MediaMeta
	{
		public int Width { get; set; }

		public int Height { get; set; }

		public string File { get; set; }

		public Dictionary<string, MediaSize> Sizes { get; set; }

		[JsonProperty("image_meta")]
		public ImageMeta ImageMeta { get; set; }
	}
}
