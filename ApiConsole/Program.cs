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
			Console.WriteLine();

			var indexResponse = await httpClient.GetAsync(api.ApiRootUri);
			var index = JsonConvert.DeserializeObject<ApiIndex>(await indexResponse.Content.ReadAsStringAsync());
			Console.WriteLine("Supported routes:");
			foreach (var route in index.Routes)
			{
				Console.WriteLine("\t" + route.Key);
			}
			Console.WriteLine();

			var postsResponse = await httpClient.GetAsync(api.ApiRootUri + "posts");
			var postsResponseContent = await postsResponse.Content.ReadAsStringAsync();
			var posts = JsonConvert.DeserializeObject<List<Post>>(postsResponseContent);

			Console.WriteLine("Recent posts:");
			foreach (var post in posts)
			{
				Console.WriteLine("\t{0}", post.Title);
			}
			Console.WriteLine();

			var mediaResponse = await httpClient.GetAsync(api.ApiRootUri + "media");
			var mediaResponseContent = await mediaResponse.Content.ReadAsStringAsync();
			var media = JsonConvert.DeserializeObject<List<Media>>(mediaResponseContent);

			Console.WriteLine("Recent media:");
			foreach (var medium in media)
			{
				Console.WriteLine("\t{0}", medium.Source);
			}
			Console.WriteLine();
		}
	}
}
