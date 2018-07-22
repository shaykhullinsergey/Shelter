using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class ConfirmationJsonModel : IValidatableObject
	{
		[DataMember(Name = "userId")]
		public string UserId { get; set; }
		
		[DataMember(Name = "code")]
		public string Code { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			validationContext.Validate(this, x => x.Code)
				.If(code => code == null || code.Length != 6)
				.Add<AuthValidation>(x => x.Confirmation.InvalidConfirmationCode);

			return validationContext.Summary();
		}
	}
}