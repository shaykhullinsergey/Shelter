using System;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class GatewayExtensions
	{
		public static void AddShelterGateways(this IServiceCollection services)
		{
			var configuration = services.BuildServiceProvider()
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<ServicesSection>();
			
			services.AddHttpClient<IAuthGateway, AuthGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.Auth);
			});
			
			services.AddHttpClient<IEmailsGateway, EmailsGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.Emails);
			});
			
			services.AddHttpClient<IErrorsGateway, ErrorsGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.Errors);
			});
			
			services.AddHttpClient<IFilesGateway, FilesGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.Files);
			});
			
			services.AddHttpClient<IMangasGateway, MangasGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.Mangas);
			});
			
			services.AddHttpClient<INewsGateway, NewsGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.News);
			});
			
			services.AddHttpClient<IProfilesGateway, ProfilesGateway>(options =>
			{
				options.BaseAddress = new Uri(configuration.Profiles);
			});
		}
	}
}