namespace Shelter
{
	public class RussianConfirmationSection : LocalizationSection<ConfirmationSection>
	{
		public RussianConfirmationSection(Localization localization) : base(localization)
		{
			Register(x => x.InvalidConfirmationCode, 
				"Некорректный код подтверждения");
		}
	}
}