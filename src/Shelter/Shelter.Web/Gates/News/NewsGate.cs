using System.Net.Http;

namespace Shelter
{
	internal class NewsGate : INewsGate
	{
		private readonly HttpClient client;

		public NewsGate(HttpClient client)
		{
			this.client = client;
		}
	}
}