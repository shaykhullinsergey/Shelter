namespace Shelter
{
	public class EnglishAuthLocalization : Localization
	{
		public EnglishAuthLocalization()
		{
			AddSection<SignupSection, EnglishSignupSection>();
		}
	}
}