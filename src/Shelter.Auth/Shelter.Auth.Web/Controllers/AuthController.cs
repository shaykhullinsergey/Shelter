using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shelter.Attributes;

namespace Shelter
{
	[Route("auth")]
	public class AuthController : ShelterController
	{
		private readonly UserManager<AuthUser> manager;
		private readonly IAuthService service;

		public AuthController(UserManager<AuthUser> manager, IAuthService service)
		{
			this.manager = manager;
			this.service = service;
		}

		[HttpPost("signup")]
		public async Task<SignedUpJsonModel> SignUp(SignUpJsonModel model)
		{
			var user = new AuthUser
			{
				UserName = model.Username,
				Email = model.Email
			};

			await service.SignUpAsync(user, model.Password);

			return new SignedUpJsonModel
			{
				UserId = user.Id
			};
		}
		
		[HttpPost("confirmation")]
		public async Task<TokenJsonModel> Confirmation(ConfirmationJsonModel model)
		{
			var tokens = await service.ConfirmEmailAsync(model.UserId, model.Code);
			
			return new TokenJsonModel
			{
				Access = tokens.Access,
				Refresh = tokens.Refresh
			};
		}
		
		[HttpPost("signin")]
		public async Task<TokenJsonModel> SignIn(SignInJsonModel model)
		{
			var tokens = await service.SignInAsync(model.Username, model.Password);
			
			return new TokenJsonModel
			{
				Access = tokens.Access,
				Refresh = tokens.Refresh
			};
		}
		
		[UserAuthorize]
		[HttpGet("signout")]
		public void SignOut()
		{
		}

		[UserAuthorize]
		[ServiceAuthorize]
		[HttpPost("refresh")]
		public void RefreshToken()
		{
		}

		[UserAuthorize]
		[HttpGet("tokens")]
		public void GetAvaliableTokens()
		{
		}
		
		[UserAuthorize]
		[HttpDelete("tokens")]
		public void DeleteTokens()
		{
		}

		[UserAuthorize]
		[HttpDelete("tokens/{tokenId:int}")]
		public void DeleteTokenById(int tokenId)
		{
		}
	}
}