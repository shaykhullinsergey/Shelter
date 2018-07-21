namespace Shelter
{
	public class EnglishAuthValidationSection : LocalizationSection<AuthValidation>
	{
		public EnglishAuthValidationSection(Localization localization) : base(localization)
		{
			Register(
				x => x.UsernameIsRequired, 
				"Username is required");
			
			Register<int>(
				x => x.UsernameLengthLimit, 
				"Username length limit is {0}");
			
			Register(
				x => x.PasswordIsRequired, 
				"Password is required");
			
			Register<int>(
				x => x.PasswordLengthLimit, 
				"Password length limit is {0}");
		}
	}
}