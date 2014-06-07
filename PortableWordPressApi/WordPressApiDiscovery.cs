using System;
using System.Net.Http;
using System.Threading.Tasks;
using PortableWordPressApi.Http;

namespace PortableWordPressApi
{
	public class WordPressApiDiscovery
	{
		private const string WpApiLinkRel = "https://github.com/WP-API/WP-API";

		private readonly HttpClient httpClient;

		public WordPressApiDiscovery(Uri siteUri, HttpClient httpClient)
		{
			this.SiteUri = siteUri;
			this.httpClient = httpClient;
		}

		public Uri SiteUri
		{
			get;
			private set;
		}

		public async Task<WordPressApi> DiscoverApiForSite()
		{
			var response = await this.httpClient.GetAsync(this.SiteUri, HttpCompletionOption.ResponseHeadersRead);
			var headers = response.Headers;
			var linkHeaders = headers.GetValues("Link");

			foreach (var linkHeader in linkHeaders)
			{
				try
				{
					var header = new LinkHeader(linkHeader);
					if (header.Relation == WpApiLinkRel)
					{
						return new WordPressApi
						{
							ApiRootUri = header.LinkUri
						};
					}
				}
				catch (ArgumentException ex)
				{
					// log malformed Link header
				}
			}

			// throw exception?
			return null;
		}
	}
}
