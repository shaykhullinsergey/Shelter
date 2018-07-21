using System.Net.Http;

namespace Shelter
{
	internal class ProfilesGate : IProfilesGate
	{
		private readonly HttpClient client;

		public ProfilesGate(HttpClient client)
		{
			this.client = client;
		}
	}
}