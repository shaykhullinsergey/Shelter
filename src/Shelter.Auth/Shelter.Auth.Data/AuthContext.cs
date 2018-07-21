using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shelter
{
	public class AuthContext : IdentityDbContext<AuthUser>
	{
		public AuthContext(DbContextOptions<AuthContext> options) : base(options)
		{
		}
	}
}