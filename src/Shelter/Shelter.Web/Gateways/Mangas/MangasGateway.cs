using System.Net.Http;

namespace Shelter
{
	internal class MangasGateway : IMangasGateway
	{
		private readonly HttpClient client;

		public MangasGateway(HttpClient client)
		{
			this.client = client;
		}
	}
}