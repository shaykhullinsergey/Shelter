using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class ShelterResponseViewModel
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
	}
	
	[DataContract]
	public class ShelterResponseViewModel<TData> : ShelterResponseViewModel
	{
		[DataMember(Name = "data")]
		public TData Data { get; set; }
	}
}