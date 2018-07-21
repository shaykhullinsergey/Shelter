using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class AuthConfiguration
	{
		[DataMember(Name = "service")]
		public ServiceConfiguration Service { get; set; }
	}
}