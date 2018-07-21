using System;
using System.Linq.Expressions;

namespace Shelter
{
	public class LocalizationSection<TComponent>
	{
		private readonly Localization localization;

		protected LocalizationSection(Localization localization)
		{
			this.localization = localization;
		}

		protected void Register(Expression<Func<TComponent, object>> expression, string value)
		{
			localization.Register(expression, value);
		}

		protected void Register<TValue>(Expression<Func<TComponent, object>> expression, string value)
		{
			localization.Register<TComponent, TValue>(expression, value);
		}
	}
}