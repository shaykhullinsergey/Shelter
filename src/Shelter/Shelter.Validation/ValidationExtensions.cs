using System.ComponentModel.DataAnnotations;

namespace Shelter
{
	public static class ValidationExtensions
	{
		public static IValidator<TModel> CreateValidator<TModel>(this ValidationContext validationContext, TModel model)
		{
			return new Validator<TModel>(validationContext, model);
		}
	}
}