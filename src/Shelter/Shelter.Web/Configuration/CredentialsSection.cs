﻿using System.Runtime.Serialization;

namespace Shelter
{
	[DataContract]
	public class CredentialsSection
	{
		[DataMember(Name = "login")]
		public string Login { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }
	}
}