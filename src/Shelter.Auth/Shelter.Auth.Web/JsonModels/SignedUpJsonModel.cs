using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class SignedUpJsonModel
	{
		[DataMember(Name = "userId")]
		public string UserId { get; set; }
	}
}