using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class IdentityExtensions
	{
		public static void AddShelterIdentity(this IServiceCollection services)
		{
			services.AddIdentity<AuthUser, IdentityRole>(options =>
				{
					options.Password.RequiredLength = 8;
					options.Password.RequiredUniqueChars = 2;
					options.Password.RequireDigit = true;
					options.Password.RequireLowercase = true;
					options.Password.RequireUppercase = true;
				})
				.AddEntityFrameworkStores<AuthContext>()
				.AddDefaultTokenProviders();
		}
	}
}