using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class AuthConfiguration : Configuration
	{
		[DataMember(Name = "auth")]
		public JwtSection Auth { get; set; }
	}
}
