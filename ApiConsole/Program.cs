using System;

namespace ApiConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter site URL:");
			var url = Console.ReadLine();

			Console.WriteLine("Searching for API at {0}", url);

			Console.WriteLine("Press any key to close.");
			Console.Read();
		}
	}
}
