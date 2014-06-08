namespace PortableWordPressApi.Resources
{
	public class PostStatus
	{
		public string Name { get; set; }

		public string Slug { get; set; }

		public bool Public { get; set; }

		public bool Protected { get; set; }

		public bool Private { get; set; }

		public bool Queryable { get; set; }

		public bool ShowInList { get; set; }

		public Meta Meta { get; set; }
	}
}
