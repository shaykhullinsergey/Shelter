using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shelter
{
	public class Profile : IValidatableObject
	{
		public int Id { get; set; }
		public string UserId { get; set; }

		public string Nickname { get; set; }
		public int Age { get; set; }
		
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			throw new System.NotImplementedException();
		}
	}
}