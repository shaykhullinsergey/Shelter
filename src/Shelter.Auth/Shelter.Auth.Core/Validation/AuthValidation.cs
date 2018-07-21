namespace Shelter
{
	public class AuthValidation : Validation
	{
		public AuthValidation(ILocalization localization) : base(localization)
		{
			Signup = AddSection<SignupSection>();
		}

		public SignupSection Signup { get; set; }
	}
}