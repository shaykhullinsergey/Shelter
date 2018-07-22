using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class TokenJsonModel
	{
		[DataMember(Name = "access")]
		public string Access { get; set; }

		[DataMember(Name = "refresh")]
		public string Refresh { get; set; }
	}
}