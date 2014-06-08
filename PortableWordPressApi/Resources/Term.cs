namespace PortableWordPressApi.Resources
{
	public class Term
	{
		public string ID { get; set; }

		public string Name { get; set; }

		public string Slug { get; set; }

		public Term Parent { get; set; }

		public int Count { get; set; }

		public Meta Meta { get; set; }
	}
}
