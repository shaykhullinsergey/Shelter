using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class ShelterResponseJsonModel
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
	}
	
	[DataContract]
	public class ShelterResponseJsonModel<TData> : ShelterResponseJsonModel
	{
		[DataMember(Name = "data")]
		public TData Data { get; set; }
	}
}