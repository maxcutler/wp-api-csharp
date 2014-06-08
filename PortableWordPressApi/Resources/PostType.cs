using System.Collections.Generic;

namespace PortableWordPressApi.Resources
{
	public class PostType
	{
		public string Name { get; set; }

		public string Slug { get; set; }

		public string Description { get; set; }

		public bool Hierarchical { get; set; }

		public bool Queryable { get; set; }

		public bool Searchable { get; set; }

		public Dictionary<string, string> Labels { get; set; } 

		public Meta Meta { get; set; }
	}
}
