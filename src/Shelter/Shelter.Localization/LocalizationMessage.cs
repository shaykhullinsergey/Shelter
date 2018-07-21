namespace Shelter
{
	public class LocalizationMessage : ILocalizationMessage
	{
		private readonly string message;

		public LocalizationMessage(string message)
		{
			this.message = message;
		}

		public string GetMessage()
		{
			return message;
		}
	}

	public class LocalizationMessage<TValue> : ILocalizationMessage
	{
		private readonly string message;

		public LocalizationMessage(string message)
		{
			this.message = message;
		}

		public string GetMessage(TValue value)
		{
			return string.Format(message, value);
		}
	}
}