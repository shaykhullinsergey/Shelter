namespace Shelter
{
	public class EnglishConfirmationSection : LocalizationSection<ConfirmationSection>
	{
		public EnglishConfirmationSection(Localization localization) : base(localization)
		{
			Register(x => x.InvalidConfirmationCode, 
				"Invalid confirmation code");
		}
	}
}