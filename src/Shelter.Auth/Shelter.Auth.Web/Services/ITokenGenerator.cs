using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Shelter
{
	public class JwtToken
	{
		public string Token { get; set; }
		
		public DateTime ExpirationDateTimeUtc { get; set; }
	}
	
	public class TokenPair
	{
		public JwtToken Access { get; set; }
		public JwtToken Refresh { get; set; }
	}
	
	public interface ITokenGenerator
	{
		Task<TokenPair> GenerateTokenPairAsync(AuthUser user);
	}
	
	public class JwtTokenGenerator : ITokenGenerator
	{
		private readonly UserManager<AuthUser> userManager;
		private readonly AuthConfiguration configuration;

		public JwtTokenGenerator(AuthConfiguration configuration, UserManager<AuthUser> userManager)
		{
			this.configuration = configuration;
			this.userManager = userManager;
		}
		
		public async Task<TokenPair> GenerateTokenPairAsync(AuthUser user)
		{
			var access = await GenerateJwtTokenAsync(configuration.Service.Jwt, user);
			var refresh = await GenerateJwtTokenAsync(configuration.Auth, user);

			return new TokenPair
			{
				Access = access,
				Refresh = refresh
			};
		}
		
		private async Task<JwtToken> GenerateJwtTokenAsync(JwtSection section, AuthUser user)
		{
			var role = (await userManager.GetRolesAsync(user)).Single();
			
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id),
				new Claim("roles", role)
			};

			var key = section.GetSecurityKey();
			
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expires = DateTime.UtcNow.AddMinutes(section.ExpireMinutes);

			var token = new JwtSecurityToken(
				section.Issuer,
				section.Issuer,
				claims,
				expires: expires,
				signingCredentials: credentials
			);
			
			return new JwtToken
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				ExpirationDateTimeUtc = expires
			};
		}
	}
}