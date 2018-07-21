using System.Net.Http;

namespace Shelter
{
	internal class ErrorsGate : IErrorsGate
	{
		private readonly HttpClient client;

		public ErrorsGate(HttpClient client)
		{
			this.client = client;
		}
	}
}