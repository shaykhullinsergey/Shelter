using System.ComponentModel;

namespace Shelter
{
	public class SignUpSection : ValidationSection<SignUpSection>
	{
		public SignUpSection(ILocalization localization) : base(localization)
		{
			UsernameIsRequired = Register(x => x.UsernameIsRequired);
			UsernameLengthMinLimit = Register<int>(x => x.UsernameLengthMinLimit);
			UsernameLengthMaxLimit = Register<int>(x => x.UsernameLengthMaxLimit);

			InvalidEmail = Register(x => x.InvalidEmail);
			
			PasswordIsRequired = Register(x => x.PasswordIsRequired);
			PasswordLengthMinLimit = Register<int>(x => x.PasswordLengthMinLimit);
			PasswordLengthMaxLimit = Register<int>(x => x.PasswordLengthMaxLimit);
		}
		
		public ValidationMessage UsernameIsRequired { get; }
		public ValidationMessage<int> UsernameLengthMinLimit { get; }
		public ValidationMessage<int> UsernameLengthMaxLimit { get; }
		
		public ValidationMessage InvalidEmail { get; set; }
		
		public ValidationMessage PasswordIsRequired { get; }
		public ValidationMessage<int> PasswordLengthMinLimit { get; }
		public ValidationMessage<int> PasswordLengthMaxLimit { get; }
	}
}