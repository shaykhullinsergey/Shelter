using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class ServiceSection
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "services")]
		public ServicesSection Services { get; set; }
		
		[DataMember(Name = "credentials")]
		public CredentialsSection Credentials { get; set; }

		[DataMember(Name = "jwt")]
		public JwtSection Jwt { get; set; }
	}
}