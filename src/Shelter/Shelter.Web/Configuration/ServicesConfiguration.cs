using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class ServicesConfiguration
	{
		[DataMember(Name = "auth")]
		public string Auth { get; set; }

		[DataMember(Name = "profiles")]
		public string Profiles { get; set; }

		[DataMember(Name = "mangas")]
		public string Mangas { get; set; }

		[DataMember(Name = "files")]
		public string Files { get; set; }
		
		[DataMember(Name = "news")]
		public string News { get; set; }

		[DataMember(Name = "errors")]
		public string Errors { get; set; }
		
		[DataMember(Name = "emails")]
		public string Emails { get; set; }
	}
}