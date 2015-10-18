using ModernDirectory.Services;
using Xamarin.Auth;
using ModernDirectory.Models;

namespace ModernDirectory.iOS.ExtensionsMethods
{
	public static class XamOAuthExtensions
	{
		public static OAuthAccount ToFormsModel (this Account xamOAuthAccount)
		{
			return new OAuthAccount {
				Username = xamOAuthAccount.Username,
				Cookies = xamOAuthAccount.Cookies,
				Properties = xamOAuthAccount.Properties
			};
		}
	}
}

