using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shelter
{
	public class EmailAuthTokenProvider : TotpSecurityStampBasedTokenProvider<AuthUser>
	{
		public override async Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<AuthUser> manager, AuthUser user)
		{
			return user.Email.IsValidEmailAddress()
				&& await manager.IsEmailConfirmedAsync(user);
		}

		public override async Task<string> GenerateAsync(string purpose, UserManager<AuthUser> manager, AuthUser user)
		{
			var code = new Random().Next(100000, 999999).ToString();
			user.ConfirmationCode = code;
			await manager.UpdateAsync(user);
			return code;
		}

		public override async Task<bool> ValidateAsync(string purpose, string token, UserManager<AuthUser> manager, AuthUser user)
		{
			if (user.ConfirmationCode == null || user.ConfirmationCode != token)
			{
				return false;
			}

			user.ConfirmationCode = null;
			await manager.UpdateAsync(user);
			return true;
		}
	}
}