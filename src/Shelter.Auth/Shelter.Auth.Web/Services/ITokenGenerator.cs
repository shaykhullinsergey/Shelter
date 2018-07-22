using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Shelter
{
	public class TokenPair
	{
		public string Access { get; set; }
		public string Refresh { get; set; }
	}
	
	public interface ITokenGenerator
	{
		Task<TokenPair> GenerateTokenPairAsync(AuthUser user);
	}
	
	public class JwtTokenGenerator : ITokenGenerator
	{
		private readonly UserManager<AuthUser> manager;
		private readonly AuthConfiguration configuration;

		public JwtTokenGenerator(AuthConfiguration configuration, UserManager<AuthUser> manager)
		{
			this.configuration = configuration;
			this.manager = manager;
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
		
		private async Task<string> GenerateJwtTokenAsync(JwtSection section, AuthUser user)
		{
			var role = (await manager.GetRolesAsync(user)).Single();
			
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id),
				new Claim("roles", role)
			};

			var key = section.GetSecurityKey();
			
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expires = DateTime.Now.AddMinutes(section.ExpireMinutes);

			var token = new JwtSecurityToken(
				section.Issuer,
				section.Issuer,
				claims,
				expires: expires,
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}