using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Shelter
{
	public interface IIfValidator<out TProperty>
	{
		IAddValidator If(Func<TProperty, bool> predicate);
	}

	internal class IfValidator<TModel, TProperty> : IIfValidator<TProperty>
	{
		private readonly ValidationContext validationContext;
		private readonly string name;
		private readonly TProperty value;
		private readonly List<ValidationResult> results;

		public IfValidator(ValidationContext validationContext, string name, TProperty value, List<ValidationResult> results)
		{
			this.validationContext = validationContext;
			this.name = name;
			this.value = value;
			this.results = results;
		}

		public IAddValidator If(Func<TProperty, bool> predicate)
		{
			var result = results.Any(x => x.MemberNames.Any(n => n == name)) || predicate(value);
			
			return new AddValidator(validationContext, name, result, results);
		}
	}
}