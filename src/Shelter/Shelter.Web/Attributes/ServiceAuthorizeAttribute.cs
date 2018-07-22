using Microsoft.AspNetCore.Authorization;

namespace Shelter.Attributes
{
	public class ServiceAuthorizeAttribute : AuthorizeAttribute
	{
		public ServiceAuthorizeAttribute()
		{
			Roles = "service";
		}
	}
}