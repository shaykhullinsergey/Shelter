using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class Configuration
	{
		[DataMember(Name = "service")]
		public ServiceSection Service { get; set; }
	}
}