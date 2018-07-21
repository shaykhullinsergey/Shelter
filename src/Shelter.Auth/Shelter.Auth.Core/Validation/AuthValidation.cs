namespace Shelter
{
	public class AuthValidation
	{
		public AuthValidation(ILocalization localization)
		{
			UsernameIsRequired = new ValidationMessage(
				localization.Localize<AuthValidation>(
					x => x.UsernameIsRequired));
			
			UsernameLengthLimit = new ValidationMessage<int>(
				localization.Localize<AuthValidation, int>(
					x => x.UsernameLengthLimit));
			
			PasswordIsRequired = new ValidationMessage(
				localization.Localize<AuthValidation>(
					x => x.PasswordIsRequired));
			
			PasswordLengthLimit = new ValidationMessage<int>(
				localization.Localize<AuthValidation, int>(
					x => x.PasswordLengthLimit));
		}

		public ValidationMessage UsernameIsRequired { get; }
		public ValidationMessage<int> UsernameLengthLimit { get; }
		
		public ValidationMessage PasswordIsRequired { get; set; }
		public ValidationMessage<int> PasswordLengthLimit { get; set; }
	}
}