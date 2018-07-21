using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shelter
{
	public class AuthContext : IdentityDbContext<AuthUser>
	{
		public AuthContext(DbContextOptions<AuthContext> options) : base(options)
		{
		}
	}
}