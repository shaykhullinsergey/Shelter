using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Shelter
{
	[DataContract]
	public class SignupViewModel : IValidatableObject
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			validationContext.Validate(this, x => x.Username)
				.If(username => string.IsNullOrWhiteSpace(username))
				.Add<AuthValidation>(x => x.Signup.UsernameIsRequired);
			
			validationContext.Validate(this, x => x.Username)
				.If(username => username.Length < 3)
				.Add<AuthValidation, int>(x => x.Signup.UsernameLengthMinLimit, 3);
			
			validationContext.Validate(this, x => x.Username)
				.If(username => username.Length > 20)
				.Add<AuthValidation, int>(x => x.Signup.UsernameLengthMaxLimit, 20);
			
			validationContext.Validate(this, x => x.Password)
				.If(password => string.IsNullOrWhiteSpace(password))
				.Add<AuthValidation>(x => x.Signup.PasswordIsRequired);
			
			validationContext.Validate(this, x => x.Password)
				.If(password => password.Length < 8)
				.Add<AuthValidation, int>(x => x.Signup.PasswordLengthMinLimit, 8);
			
			validationContext.Validate(this, x => x.Password)
				.If(password => password.Length > 32)
				.Add<AuthValidation, int>(x => x.Signup.PasswordLengthMaxLimit, 32);

			return validationContext.Summary();
		}
	}
}