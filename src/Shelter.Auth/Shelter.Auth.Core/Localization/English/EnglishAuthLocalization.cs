namespace Shelter
{
	public class EnglishAuthLocalization : Localization
	{
		public EnglishAuthLocalization()
		{
			AddSection<SignUpSection, EnglishSignUpSection>();
			AddSection<SignInSection, EnglishSignInSection>();
			AddSection<ConfirmationSection, EnglishConfirmationSection>();
		}
	}
}