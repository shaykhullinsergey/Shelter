﻿using System;

namespace Shelter
{
	public class RefreshToken
	{
		public int Id { get; set; }

		public string UserId { get; set; }
		public AuthUser User { get; set; }
		
		public string Token { get; set; }
		public DateTime ExpirationDateTimeUtc { get; set; }
	}
}