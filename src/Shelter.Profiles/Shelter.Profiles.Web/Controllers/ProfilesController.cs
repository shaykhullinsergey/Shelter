using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shelter
{
	[Authorize]
	[Route("profiles")]
	public class ProfilesController : ShelterController
	{
	}
}