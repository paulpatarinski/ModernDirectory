using System.Collections.Generic;
using Newtonsoft.Json;
using ModernDirectory.Utilities.ExtensionsMethods;

namespace ModernDirectory.Models
{
	public class GooglePeoplePayload
	{
		public string nextPageToken { get; set; }

		[JsonProperty(PropertyName="items")] 
		public List<Person> People { get; set; }
	}

	public class Image
	{
		public string Url { get; set; }
	}

	public class Person
	{
		public string DisplayName { get; set; }
		public Image Image { get; set; }

		public string Initials
		{
			get{
				return DisplayName.GetInitials ();
			}
		}
	}
}