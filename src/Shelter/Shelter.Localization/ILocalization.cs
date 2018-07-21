using System;
using System.Linq.Expressions;

namespace Shelter
{
	public interface ILocalization
	{
		LocalizationMessage Localize<TComponent>(Expression<Func<TComponent, object>> expression);
		LocalizationMessage<TValue> Localize<TComponent, TValue>(Expression<Func<TComponent, object>> expression);
	}
}