namespace Shelter
{
	public class RussianSignUpSection : LocalizationSection<SignUpSection>
	{
		public RussianSignUpSection(Localization localization) : base(localization)
		{
			Register(x => x.UsernameIsRequired, 
				"Требуется ввести имя пользователя");
			Register<int>(x => x.UsernameLengthMinLimit,
				"Длина имени пользователя меньше {0} символов");
			Register<int>(x => x.UsernameLengthMaxLimit, 
				"Максимальная длина имени пользователя: {0} символов");
			
			Register(x => x.InvalidEmail,
				"Неверный email адрес");
			
			Register(x => x.PasswordIsRequired,
				"Требуется ввести пароль");
			Register<int>(x => x.PasswordLengthMinLimit,
				"Длина пароля меньше {0} символов");
			Register<int>(x => x.PasswordLengthMaxLimit, 
				"Максимальная длина пароля: {0} символов");
		}
	}
}