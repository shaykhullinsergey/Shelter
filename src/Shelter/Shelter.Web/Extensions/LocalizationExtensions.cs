using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class LocalizationExtensions
	{
		public static void AddLocalization<TLocalization>(this IServiceCollection services)
			where TLocalization : Localization
		{
			services.AddSingleton<ILocalization, TLocalization>();
		}
	}
}