using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shelter
{
	public class AuthContext : IdentityDbContext<AuthUser>
	{
		public AuthContext(DbContextOptions<AuthContext> options) : base(options)
		{
		}
		
		public DbSet<RefreshToken> RefreshTokens { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new RefreshTokenTypeConfiguration());
			base.OnModelCreating(builder);
		}
	}
}