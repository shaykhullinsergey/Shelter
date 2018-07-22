using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Shelter
{
	public class AuthUser : IdentityUser
	{
		public string ConfirmationCode { get; set; }
		
		public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
	}
}