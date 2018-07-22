using Microsoft.EntityFrameworkCore;

namespace Shelter
{
	public class ProfilesContext : ShelterContext
	{
		public ProfilesContext(DbContextOptions<ProfilesContext> options) : base(options)
		{
		}

		public DbSet<Profile> Profiles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProfilesTypeConfiguration());
		}
	}
}