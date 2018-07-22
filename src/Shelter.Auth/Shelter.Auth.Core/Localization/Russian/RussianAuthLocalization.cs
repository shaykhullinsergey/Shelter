namespace Shelter
{
	public class RussianAuthLocalization : Localization
	{
		public RussianAuthLocalization()
		{
			AddSection<SignUpSection, RussianSignUpSection>();
			AddSection<SignInSection, RussianSignInSection>();
			AddSection<ConfirmationSection, RussianConfirmationSection>();
		}
	}
}