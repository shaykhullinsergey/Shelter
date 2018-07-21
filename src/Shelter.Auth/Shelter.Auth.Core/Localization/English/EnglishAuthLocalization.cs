namespace Shelter
{
	public class EnglishAuthLocalization : Localization
	{
		public EnglishAuthLocalization()
		{
			AddSection<AuthValidation, EnglishAuthValidationSection>();
		}
	}
}