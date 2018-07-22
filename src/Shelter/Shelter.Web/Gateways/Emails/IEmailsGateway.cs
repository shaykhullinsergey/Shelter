using System.Threading.Tasks;

namespace Shelter
{
	public interface IEmailsGateway
	{
		Task SendAsync(string email, string message);
	}
}