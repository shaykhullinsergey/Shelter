using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class ValidationExtensions
	{
		public static void AddShelterValidation<TValidation>(this IServiceCollection services)
			where TValidation : Validation
		{
			services.AddSingleton<TValidation>();
		}
	}
}