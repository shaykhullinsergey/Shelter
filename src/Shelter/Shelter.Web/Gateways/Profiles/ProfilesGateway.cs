using System.Net.Http;

namespace Shelter
{
	internal class ProfilesGateway : IProfilesGateway
	{
		private readonly HttpClient client;

		public ProfilesGateway(HttpClient client)
		{
			this.client = client;
		}
	}
}