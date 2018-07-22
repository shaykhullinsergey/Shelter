namespace Shelter
{
	public class EnglishSignInSection : LocalizationSection<SignInSection>
	{
		public EnglishSignInSection(Localization localization) : base(localization)
		{
			Register(x => x.UsernameIsRequired, 
				"Username is required");
			Register<int>(x => x.UsernameLengthMinLimit,
				"Username length less than {0} characters");
			Register<int>(x => x.UsernameLengthMaxLimit, 
				"Username length limit is {0} characters");
			
			Register(x => x.PasswordIsRequired, 
				"Password is required");
			Register<int>(x => x.PasswordLengthMinLimit,
				"Password length less than {0} characters");
			Register<int>(x => x.PasswordLengthMaxLimit, 
				"Password length limit is {0} characters");
		}
	}
}