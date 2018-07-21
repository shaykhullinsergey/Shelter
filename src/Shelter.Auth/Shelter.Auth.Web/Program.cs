using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Shelter
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		private static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder<Startup>(args)
				.Build();
	}
}