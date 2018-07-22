namespace Shelter
{
	public class ConfirmationSection : ValidationSection<ConfirmationSection>
	{
		public ConfirmationSection(ILocalization localization) : base(localization)
		{
			InvalidConfirmationCode = Register(x => x.InvalidConfirmationCode);
		}
		
		public ValidationMessage InvalidConfirmationCode { get; }
	}
}