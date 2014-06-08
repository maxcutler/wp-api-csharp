using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PortableWordPressApi;
using PortableWordPressApi.Resources;

namespace ApiConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Task.WaitAll(AsyncMain());

			Console.WriteLine("Press any key to close.");
			Console.Read();
		}

		private static async Task AsyncMain()
		{
			Console.WriteLine("Enter site URL:");
			var url = Console.ReadLine();

			Console.WriteLine("Searching for API at {0}", url);

			var httpClient = new HttpClient();
			var discovery = new WordPressApiDiscovery(new Uri(url, UriKind.Absolute), httpClient);
			var api = await discovery.DiscoverApiForSite();

			Console.WriteLine("Site's API endpoint: {0}", api.ApiRootUri);

			var indexResponse = await httpClient.GetAsync(api.ApiRootUri);
			var index = JsonConvert.DeserializeObject<ApiIndex>(await indexResponse.Content.ReadAsStringAsync());
			Console.WriteLine("Supported routes:");
			foreach (var route in index.Routes)
			{
				Console.WriteLine("\t" + route.Key);
			}

			var postsResponse = await httpClient.GetAsync(api.ApiRootUri + "posts");
			var posts = JsonConvert.DeserializeObject<List<Post>>(await postsResponse.Content.ReadAsStringAsync());
		}
	}
}
