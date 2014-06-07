using System;
using System.Net.Http;
using System.Threading.Tasks;
using PortableWordPressApi;

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
		}
	}
}
