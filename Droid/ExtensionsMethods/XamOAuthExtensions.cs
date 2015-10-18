using System;
using ModernDirectory.Services;
using Xamarin.Auth;

namespace ModernDirectory.Droid.ExtensionsMethods
{
	public static class XamOAuthExtensions
	{
		public static OAuthAccount ToFormsModel(this Account xamOAuthAccount)
		{
			return new OAuthAccount {
				Username = xamOAuthAccount.Username,
				Cookies = xamOAuthAccount.Cookies,
				Properties = xamOAuthAccount.Properties
			};
		}
	}
}

