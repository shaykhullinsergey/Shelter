using System;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class GateExtensions
	{
		public static void AddGates(this IServiceCollection services)
		{
			var configuration = services.BuildServiceProvider()
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<ServicesConfiguration>();
			
			services.AddHttpClient<IAuthGate, AuthGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.Auth);
			});
			
			services.AddHttpClient<IEmailsGate, EmailsGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.Emails);
			});
			
			services.AddHttpClient<IErrorsGate, ErrorsGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.Errors);
			});
			
			services.AddHttpClient<IFilesGate, FilesGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.Files);
			});
			
			services.AddHttpClient<IMangasGate, MangasGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.Mangas);
			});
			
			services.AddHttpClient<INewsGate, NewsGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.News);
			});
			
			services.AddHttpClient<IProfilesGate, ProfilesGate>(options =>
			{
				options.BaseAddress = new Uri(configuration.Profiles);
			});
		}
	}
}