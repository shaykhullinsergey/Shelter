﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shelter
{
	public interface IAuthService
	{
		Task SignUpAsync(AuthUser user, string password);
		Task<TokenPair> SignInAsync(string username, string password);
		Task<TokenPair> ConfirmEmailAsync(string userId, string code);
	}

	public class AuthService : IAuthService
	{
		private readonly IEmailsGateway gateway;
		private readonly ITokenGenerator generator;
		private readonly UserManager<AuthUser> userManager;
		private readonly SignInManager<AuthUser> signInManager;

		public AuthService(
			UserManager<AuthUser> userManager, 
			SignInManager<AuthUser> signInManager, 
			IEmailsGateway gateway,
			ITokenGenerator generator)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.gateway = gateway;
			this.generator = generator;
		}
		
		public async Task SignUpAsync(AuthUser user, string password)
		{
			var result = await userManager.CreateAsync(user, password);

			if (!result.Succeeded)
			{
				throw new ShelterValidationException(HandleValidationErrors(result));
			}

			await userManager.AddToRoleAsync(user, "user");
			var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
			await gateway.SendAsync(user.Email, code);
		}
		

		public async Task<TokenPair> SignInAsync(string username, string password)
		{
			var result = await signInManager.PasswordSignInAsync(username, password, false, false);
			
			if (result.Succeeded)
			{
				var user = await userManager.FindByNameAsync(username);
				return await GenerateToUserAsync(user);
			}
			
			throw new UnauthorizedAccessException();
		}

		
		public async Task<TokenPair> ConfirmEmailAsync(string userId, string code)
		{
			var user = await userManager.FindByIdAsync(userId);
			var result = await userManager.ConfirmEmailAsync(user, code);

			if (result.Succeeded)
			{
				return await GenerateToUserAsync(user);
			}
			
			throw new ShelterValidationException(HandleValidationErrors(result));
		}
		

		private async Task<TokenPair> GenerateToUserAsync(AuthUser user)
		{
			var tokens = await generator.GenerateTokenPairAsync(user);

			var refresh = new RefreshToken
			{
				User = user,
				Token = tokens.Refresh.Token,
				ExpirationDateTimeUtc = tokens.Refresh.ExpirationDateTimeUtc
			};
				
			user.RefreshTokens.Add(refresh);

			await userManager.UpdateAsync(user);

			return tokens;
		}

		private ValidationResult[] HandleValidationErrors(IdentityResult result)
		{
			var name = new[] { "auth" };
			
			return result.Errors
				.Select(x => new ValidationResult(x.Description, name))
				.ToArray();
		}
	}
}