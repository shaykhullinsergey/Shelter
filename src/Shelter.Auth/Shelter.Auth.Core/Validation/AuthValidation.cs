namespace Shelter
{
	public class AuthValidation : Validation
	{
		public AuthValidation(ILocalization localization) : base(localization)
		{
			SignUp = AddSection<SignUpSection>();
			Signin = AddSection<SignInSection>();
			Confirmation = AddSection<ConfirmationSection>();
		}

		public SignUpSection SignUp { get; set; }
		public SignInSection Signin { get; set; }
		public ConfirmationSection Confirmation { get; set; }
	}
}