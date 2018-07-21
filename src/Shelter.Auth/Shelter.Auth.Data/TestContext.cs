using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shelter
{
	public class TestEntity : IValidatableObject
	{
		public int Id { get; set; }
		public string Test { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			validationContext.Validate(this, x => x.Test)
				.If(test => true)
				.Add<AuthValidation>(x => x.PasswordIsRequired);

			return validationContext.Summary();
		}
	}
	
	public class TestContext : ShelterContext
	{
		public DbSet<TestEntity> Entities { get; set; }
		
		public TestContext(DbContextOptions<TestContext> options) 
			: base(options)
		{
		}
	}
}