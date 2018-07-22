using System.Runtime.Serialization;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Shelter
{
	[DataContract]
	public class JwtSection
	{
		[DataMember(Name = "secret")]
		public string Secret { get; set; }
		
		[DataMember(Name = "issuer")]
		public string Issuer { get; set; }
		
		[DataMember(Name = "expireMinutes")]
		public int ExpireMinutes { get; set; }
		
		public SecurityKey GetSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
		}
	}
}