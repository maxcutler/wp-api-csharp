using System.Collections.Generic;

namespace PortableWordPressApi.Resources
{
	public class ApiIndex
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string URL { get; set; }

		public Dictionary<string, ApiIndexRoute> Routes { get; set; } 

		public Meta Meta { get; set; }
	}

	public class ApiIndexRoute
	{
		public List<string> Supports { get; set; }

		public Meta Meta { get; set; }
	}
}
