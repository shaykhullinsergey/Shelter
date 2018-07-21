using System;
using System.Linq.Expressions;

namespace Shelter
{
	public class Validation
	{
		private readonly ILocalization localization;

		public Validation(ILocalization localization)
		{
			this.localization = localization;
		}
		
		public ValidationMessage Register<TComponent>(Expression<Func<TComponent, object>> expression)
		{
			return new ValidationMessage(
				localization.Localize(expression));
		}

		public ValidationMessage<TValue> Register<TComponent, TValue>(Expression<Func<TComponent, object>> expression)
		{
			return new ValidationMessage<TValue>(
				localization.Localize<TComponent, TValue>(expression));
		}

		public TSection AddSection<TSection>()
			where TSection : ValidationSection<TSection>
		{
			return (TSection)Activator.CreateInstance(typeof(TSection), localization);
		}
	}

	public class ValidationSection<TComponent>
	{
		private readonly ILocalization localization;

		public ValidationSection(ILocalization localization)
		{
			this.localization = localization;
		}
		
		public ValidationMessage Register(Expression<Func<TComponent, object>> expression)
		{
			return new ValidationMessage(
				localization.Localize(expression));
		}

		public ValidationMessage<TValue> Register<TValue>(Expression<Func<TComponent, object>> expression)
		{
			return new ValidationMessage<TValue>(
				localization.Localize<TComponent, TValue>(expression));
		}
	}
}