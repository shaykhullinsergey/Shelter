using Microsoft.AspNetCore.Authorization;

namespace Shelter
{
	public class UserAuthorizeAttribute : AuthorizeAttribute
	{
		public UserAuthorizeAttribute()
		{
			Roles = "user";
		}
	}
}