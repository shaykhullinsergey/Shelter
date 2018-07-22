using System.Net.Http;

namespace Shelter
{
	internal class ErrorsGateway : IErrorsGateway
	{
		private readonly HttpClient client;

		public ErrorsGateway(HttpClient client)
		{
			this.client = client;
		}
	}
}