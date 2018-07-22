using System.Net.Http;
using System.Threading.Tasks;

namespace Shelter
{
	public class EmailsGateway : IEmailsGateway
	{
		private readonly HttpClient client;

		public EmailsGateway(HttpClient client)
		{
			this.client = client;
		}
		
		public Task SendAsync(string email, string message)
		{
			return Task.CompletedTask;
		}
	}
}