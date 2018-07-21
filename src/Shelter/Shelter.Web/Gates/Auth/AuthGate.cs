using System.Net.Http;

namespace Shelter
{
	internal class AuthGate : IAuthGate
	{
		private readonly HttpClient client;

		public AuthGate(HttpClient client)
		{
			this.client = client;
		}
	}
}