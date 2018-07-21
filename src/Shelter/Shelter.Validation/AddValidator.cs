using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shelter
{
	public interface IAddValidator
	{
		void Add<TValidationDictionary>(Func<TValidationDictionary, ValidationMessage> selector)
			where TValidationDictionary : class;
		
		void Add<TValidationDictionary, TValue>(Func<TValidationDictionary, ValidationMessage<TValue>> selector, TValue value)
			where TValidationDictionary : class;
	}

	internal class AddValidator : IAddValidator
	{
		private readonly ValidationContext validationContext;
		private readonly string name;
		private readonly bool result;
		private readonly List<ValidationResult> results;

		public AddValidator(ValidationContext validationContext, string name, bool result, List<ValidationResult> results)
		{
			this.validationContext = validationContext;
			this.name = name;
			this.result = result;
			this.results = results;
		}
			
		public void Add<TValidationDictionary>(Func<TValidationDictionary, ValidationMessage> selector)
			where TValidationDictionary : class
		{
			if (result)
			{
				var dictionary = (TValidationDictionary)validationContext.GetService(typeof(TValidationDictionary));
				
				results.Add(new ValidationResult(selector(dictionary).GetMessage(), new[]{name}));
			}
		}
		
		public void Add<TValidationDictionary, TValue>(Func<TValidationDictionary, ValidationMessage<TValue>> selector, TValue value)
			where TValidationDictionary : class
		{
			if (result)
			{
				var dictionary = (TValidationDictionary)validationContext.GetService(typeof(TValidationDictionary));
				
				results.Add(new ValidationResult(selector(dictionary).GetMessage(value), new[]{name}));
			}
		}
	}
}