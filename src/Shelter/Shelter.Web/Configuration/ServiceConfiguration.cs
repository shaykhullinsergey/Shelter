using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class ServiceConfiguration
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "services")]
		public ServicesConfiguration Services { get; set; }
		
		[DataMember(Name = "credentials")]
		public CredentialsConfiguration Credentials { get; set; }

		[DataMember(Name = "jwt")]
		public JwtConfiguration Jwt { get; set; }
	}
}