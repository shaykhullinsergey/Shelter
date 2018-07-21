namespace Shelter
{
	public class ValidationMessage
	{
		private readonly LocalizationMessage message;

		public ValidationMessage(LocalizationMessage message)
		{
			this.message = message;
		}

		public string GetMessage()
		{
			return message.GetMessage();
		}
	}

	public class ValidationMessage<TValue>
	{
		private readonly LocalizationMessage<TValue> message;

		public ValidationMessage(LocalizationMessage<TValue> message)
		{
			this.message = message;
		}

		public string GetMessage(TValue value)
		{
			return message.GetMessage(value);
		}
	}
}