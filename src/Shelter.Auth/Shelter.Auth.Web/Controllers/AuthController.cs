using Microsoft.AspNetCore.Mvc;

namespace Shelter
{
	[Route("auth")]
	public class AuthController : ShelterController
	{
		[HttpPost]
		public string Signup(SignupViewModel model, [FromServices] IEmailsGate emails)
		{
			return emails.GetString();
		}
	}
}