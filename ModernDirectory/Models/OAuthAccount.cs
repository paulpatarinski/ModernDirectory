using System;
using System.Net;
using System.Collections.Generic;

namespace ModernDirectory.Models
{
	public class OAuthAccount
	{
		public string Username {
			get;
			set;
		}

		public CookieContainer Cookies {
			get;
			set;
		}

		public Dictionary<string,string> Properties {
			get;
			set;
		}
	}
}

