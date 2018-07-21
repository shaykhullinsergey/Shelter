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
			var validator = validationContext.CreateValidator(this);

			validator.Validate(x => x.Username)
				.If(username => string.IsNullOrWhiteSpace(username))
				.Add<AuthValidation>(x => x.UsernameIsRequired);
			
			validator.Validate(x => x.Username)
				.If(username => username.Length > 20)
				.Add<AuthValidation, int>(x => x.UsernameLengthLimit, 20);
			
			validator.Validate(x => x.Password)
				.If(password => string.IsNullOrWhiteSpace(password))
				.Add<AuthValidation>(x => x.PasswordIsRequired);
			
			validator.Validate(x => x.Password)
				.If(password => password.Length > 20)
				.Add<AuthValidation, int>(x => x.PasswordLengthLimit, 20);

			return validator.Summary();
		}
	}
}