using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class JwtConfiguration
	{
		[DataMember(Name = "jwtKey")]
		public string JwtKey { get; set; }
		
		[DataMember(Name = "jwtIssuer")]
		public string JwtIssuer { get; set; }
		
		[DataMember(Name = "jwtExpireDays")]
		public string JwtExpireDays { get; set; }
	}
}