﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Shelter
{
	public class Localization : ILocalization
	{
		private readonly Dictionary<string, ILocalizationMessage> values;

		public Localization()
		{
			values = new Dictionary<string, ILocalizationMessage>();
		}
		
		public void Register<TComponent>(Expression<Func<TComponent, object>> expression, string value)
		{
			var key = GetKey(expression);
			var message = new LocalizationMessage(key, value);
			values.Add(key, message);
		}
		
		public void Register<TComponent, TValue>(Expression<Func<TComponent, object>> expression, string value)
		{
			var key = GetKey(expression);
			var message = new LocalizationMessage<TValue>(key, value);
			values.Add(key, message);
		}
		
		public LocalizationMessage Localize<TComponent>(Expression<Func<TComponent, object>> expression)
		{
			return (LocalizationMessage) GetValue(expression);
		}
		
		public LocalizationMessage<TValue> Localize<TComponent, TValue>(Expression<Func<TComponent, object>> expression)
		{
			return (LocalizationMessage<TValue>) GetValue(expression);
		}

		public void AddSection<TComponent, TSection>()
			where TSection : LocalizationSection<TComponent>
		{
			Activator.CreateInstance(typeof(TSection), this);
		}

		private string GetKey<TComponent>(Expression<Func<TComponent, object>> expression)
		{
			string name;

			switch (expression.Body)
			{
				case MemberExpression e:
					name = e.Member.Name;
					break;
				case MethodCallExpression e:
					name = e.Method.Name;
					break;
				default:
					throw new KeyNotFoundException();
			}
			
			var typeName = typeof(TComponent).Name;
			
			return $"{typeName}:{name}";
		}

		private ILocalizationMessage GetValue<TComponent>(Expression<Func<TComponent, object>> expression)
		{
			var key = GetKey(expression);

			if (values.TryGetValue(key, out var value))
			{
				return value;
			}
			
			throw new InvalidOperationException(
				$"Localization key {key} is not registered for {typeof(TComponent).Name} component");
		}
	}
}