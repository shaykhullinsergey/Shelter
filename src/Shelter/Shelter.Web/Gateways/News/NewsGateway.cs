using System.Net.Http;

namespace Shelter
{
	internal class NewsGateway : INewsGateway
	{
		private readonly HttpClient client;

		public NewsGateway(HttpClient client)
		{
			this.client = client;
		}
	}
}