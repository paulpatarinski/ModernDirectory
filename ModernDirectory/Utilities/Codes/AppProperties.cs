using System;
using Xamarin.Forms;

namespace ModernDirectory.Utilities.Codes
{
	public static class AppProperties
	{
		public static string LinkedInAccessKey{get{
				object key;

				Application.Current.Properties.TryGetValue ("linkedinAccessKey", out key);

				return key == null ? string.Empty : key.ToString ();
			}
			set{

				if(Application.Current.Properties.ContainsKey ("linkedinAccessKey"))
				{
					Application.Current.Properties ["linkedinAccessKey"] = value;
				}
				else{
					Application.Current.Properties.Add ("linkedinAccessKey", value);
				}
			}}
	}
}

