namespace PortableWordPressApi.Resources
{
	public class User
	{
		public string ID { get; set; }

		public string Name { get; set; }

		public string Slug { get; set; }

		public string Url { get; set; }

		public string Avatar { get; set; }

		public Meta Meta { get; set; }
	}
}
