namespace Shelter
{
	public class RussianAuthValidationSection : LocalizationSection<AuthValidation>
	{
		public RussianAuthValidationSection(Localization localization) : base(localization)
		{
			Register(
				x => x.UsernameIsRequired, 
				"Требуется ввести имя пользователя");
			
			Register<int>(
				x => x.UsernameLengthLimit, 
				"Максимальная длина имени пользователя: {0} символов");
			
			Register(
				x => x.PasswordIsRequired,
				"Требуется ввести пароль");
			
			Register<int>(
				x => x.PasswordLengthLimit, 
				"Максимальная длина пароля: {0} символов");
		}
	}
}