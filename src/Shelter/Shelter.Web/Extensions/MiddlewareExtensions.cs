using Microsoft.AspNetCore.Builder;

namespace Shelter
{
	public static class MiddlewareExtensions
	{
		public static void UseErrorHandling(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlingMiddleware>();
		}
	}
}