using Microsoft.AspNetCore.Authorization;

namespace Shelter
{
	public class ServiceAuthorizeAttribute : AuthorizeAttribute
	{
		public ServiceAuthorizeAttribute()
		{
			Roles = "service";
		}
	}
}