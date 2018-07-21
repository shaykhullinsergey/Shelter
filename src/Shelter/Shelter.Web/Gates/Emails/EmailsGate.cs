using System.Net.Http;

namespace Shelter
{
	public class EmailsGate : IEmailsGate
	{
		private readonly HttpClient client;

		public EmailsGate(HttpClient client)
		{
			this.client = client;
		}
		
		public string GetString()
		{
			return "It Works!!";
		}
	}
}