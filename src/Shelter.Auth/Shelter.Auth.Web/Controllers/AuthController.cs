using Microsoft.AspNetCore.Mvc;

namespace Shelter
{
	[Route("auth")]
	public class AuthController : ShelterController
	{
		[HttpPost]
		public string Signup(SignupViewModel model, [FromServices] TestContext context)
		{
			var e = new TestEntity();

			context.Add(e);

			context.SaveChanges();

			return "asd";
		}
	}
}