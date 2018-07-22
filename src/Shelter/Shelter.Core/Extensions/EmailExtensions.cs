namespace Shelter
{
	public static class EmailExtensions
	{
		public static bool IsValidEmailAddress(this string email)
		{
			if (email == null)
			{
				return false;
			}
			
			var flag = false;
			for (var index = 0; index < email.Length; ++index)
			{
				if (email[index] == '@')
				{
					if (flag || index == 0 || index == email.Length - 1)
					{
						return false;
					}
					
					flag = true;
				}
			}
			return flag;
		}
	}
}