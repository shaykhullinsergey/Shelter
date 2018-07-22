namespace Shelter
{
	public class LocalizationMessage : ILocalizationMessage
	{
		private readonly string message;

		public LocalizationMessage(string key, string message)
		{
			Key = key;
			this.message = message;
		}
		
		public string Key { get; }

		public string GetMessage()
		{
			return message;
		}
	}

	public class LocalizationMessage<TValue> : ILocalizationMessage
	{
		private readonly string message;

		public LocalizationMessage(string key, string message)
		{
			Key = key;
			this.message = message;
		}
		
		public string Key { get; }

		public string GetMessage(TValue value)
		{
			return string.Format(message, value);
		}
	}
}