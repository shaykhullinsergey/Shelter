using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Shelter
{
	public interface IValidator<TModel>
	{
		IIfValidator<TProperty> Validate<TProperty>(Expression<Func<TModel, TProperty>> expression);
		IEnumerable<ValidationResult> Summary();
	}

	internal class Validator<TModel> : IValidator<TModel>
	{
		private readonly ValidationContext validationContext;
		private readonly TModel model;
		private readonly List<ValidationResult> results;

		public Validator(ValidationContext validationContext, TModel model)
		{
			this.validationContext = validationContext;
			this.model = model;
			results = new List<ValidationResult>();
		}

		public IIfValidator<TProperty> Validate<TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			var member = (expression.Body as MemberExpression).Member;

			var name = member.GetCustomAttribute<DataMemberAttribute>().Name ?? member.Name;
			var value = expression.Compile().Invoke(model);
			
			return new IfValidator<TModel, TProperty>(validationContext, name, value, results);
		}

		public IEnumerable<ValidationResult> Summary()
		{
			return results;
		}
	}
}