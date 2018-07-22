using System.Net.Http;

namespace Shelter
{
	internal class AuthGateway : IAuthGateway
	{
		private readonly HttpClient client;

		public AuthGateway(HttpClient client)
		{
			this.client = client;
		}
	}
}