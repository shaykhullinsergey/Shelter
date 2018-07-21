using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Shelter
{
	public static class ValidationExtensions
	{
		public static IEnumerable<ValidationResult> Summary(this ValidationContext validationContext)
		{
			return validationContext.Items.Values
				.OfType<IEnumerable<ValidationResult>>()
				.SelectMany(x => x);
		}
		
		public static IIfValidator<TProperty> Validate<TModel, TProperty>(this ValidationContext validationContext, TModel model, Expression<Func<TModel, TProperty>> expression)
		{
			var member = (expression.Body as MemberExpression).Member;

			var name = member.GetCustomAttribute<DataMemberAttribute>()?.Name ?? member.Name;
			var value = expression.Compile().Invoke(model);

			List<ValidationResult> validationMessages;

			if (validationContext.Items.TryGetValue(typeof(TModel).Name, out var list))
			{
				validationMessages = (List<ValidationResult>) list;
			}
			else
			{
				validationMessages = new List<ValidationResult>();
				validationContext.Items.Add(typeof(TModel).Name, validationMessages);
			}
			
			return new IfValidator<TModel, TProperty>(validationContext, name, value, validationMessages);
		}
	}
}