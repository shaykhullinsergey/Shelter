using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class SignInJsonModel : IValidatableObject
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			validationContext.Validate(this, x => x.Username)
				.If(username => string.IsNullOrWhiteSpace(username))
				.Add<AuthValidation>(x => x.SignUp.UsernameIsRequired);
			
			validationContext.Validate(this, x => x.Username)
				.If(username => username.Length < 2)
				.Add<AuthValidation, int>(x => x.SignUp.UsernameLengthMinLimit, 2);
			
			validationContext.Validate(this, x => x.Username)
				.If(username => username.Length > 20)
				.Add<AuthValidation, int>(x => x.SignUp.UsernameLengthMaxLimit, 20);
			
			validationContext.Validate(this, x => x.Password)
				.If(password => string.IsNullOrWhiteSpace(password))
				.Add<AuthValidation>(x => x.SignUp.PasswordIsRequired);
			
			validationContext.Validate(this, x => x.Password)
				.If(password => password.Length < 8)
				.Add<AuthValidation, int>(x => x.SignUp.PasswordLengthMinLimit, 8);
			
			validationContext.Validate(this, x => x.Password)
				.If(password => password.Length > 32)
				.Add<AuthValidation, int>(x => x.SignUp.PasswordLengthMaxLimit, 32);

			return validationContext.Summary();
		}
	}
}