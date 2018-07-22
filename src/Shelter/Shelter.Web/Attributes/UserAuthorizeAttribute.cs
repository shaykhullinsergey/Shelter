using Microsoft.AspNetCore.Authorization;

namespace Shelter.Attributes
{
	public class UserAuthorizeAttribute : AuthorizeAttribute
	{
		public UserAuthorizeAttribute()
		{
			Roles = "user";
		}
	}
}