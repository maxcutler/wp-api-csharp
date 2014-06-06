using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortableWordPressApi
{
	public class WordPressApiDiscovery
	{
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
				// parse link headers
			}

			return new WordPressApi
			{
				ApiRootUri = this.SiteUri
			};
		}
	}
}
