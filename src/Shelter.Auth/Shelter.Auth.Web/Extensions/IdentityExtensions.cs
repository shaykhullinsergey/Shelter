using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class IdentityExtensions
	{
		public static void AddAuthIdentity(this IServiceCollection services)
		{
			services.AddIdentity<AuthUser, IdentityRole>(options =>
				{
					options.Password = new PasswordOptions
					{
						RequiredLength = 8,
						RequiredUniqueChars = 2,
						RequireNonAlphanumeric = false,
						RequireDigit = false,
						RequireLowercase = false,
						RequireUppercase = false,
					};

					options.Tokens.EmailConfirmationTokenProvider = "ShelterEmailProvider";
					options.User.RequireUniqueEmail = true;
					options.SignIn.RequireConfirmedEmail = true;
				})
				.AddEntityFrameworkStores<AuthContext>()
				.AddDefaultTokenProviders()
				.AddTokenProvider<EmailAuthTokenProvider>("ShelterEmailProvider");
		}

		public static void ConfigureInMemoryDatabase(this IApplicationBuilder app)
		{
			var manager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

			manager.CreateAsync(new IdentityRole
			{
				Name = "user"
			}).GetAwaiter().GetResult();
		}
	}
}