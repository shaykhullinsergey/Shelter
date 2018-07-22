using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shelter
{
	public class RefreshTokenTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
	{
		public void Configure(EntityTypeBuilder<RefreshToken> builder)
		{
			builder.HasOne(x => x.User)
				.WithMany(x => x.RefreshTokens)
				.HasForeignKey(x => x.UserId);
		}
	}
}