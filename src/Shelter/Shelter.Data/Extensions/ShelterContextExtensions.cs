using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class ShelterContextExtensions
	{
		public static void AddShelterInMemoryDbContextPool<TContext>(this IServiceCollection services)
			where TContext : ShelterContext
		{
			services.AddEntityFrameworkInMemoryDatabase();
			services.AddDbContextPool<TContext>(options =>
			{
				options.UseInMemoryDatabase(nameof(TContext));
				options.UseInternalServiceProvider(services.BuildServiceProvider());
			});
		}
	}
}