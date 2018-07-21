namespace Shelter
{
	public class RussianAuthLocalization : Localization
	{
		public RussianAuthLocalization()
		{
			AddSection<AuthValidation, RussianAuthValidationSection>();
		}
	}
}