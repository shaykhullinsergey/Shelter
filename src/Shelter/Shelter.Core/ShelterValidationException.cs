using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Shelter
{
	public class ShelterValidationException : ValidationException
	{
		public IEnumerable<ValidationResult> ValidationResults { get; }

		public ShelterValidationException(IEnumerable<ValidationResult> validationResults)
		{
			ValidationResults = validationResults;
		}

		public Dictionary<string, string[]> GetValidationMessage()
		{
			return ValidationResults.GroupBy(x => x.MemberNames.Single())
				.ToDictionary(
					g => g.Key, 
					g => g.Select(x => x.ErrorMessage).ToArray());
		}
	}
}