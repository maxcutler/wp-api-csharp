using Newtonsoft.Json;

namespace PortableWordPressApi.Resources
{
	public class MediaSize
	{
		public string File { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }

		[JsonProperty("mime-type")]
		public string MimeType { get; set; }

		public string Url { get; set; }
	}
}
