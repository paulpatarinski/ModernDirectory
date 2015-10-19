using System;
using ModernDirectory.Utilities.ExtensionsMethods;

namespace ModernDirectory.Models
{
	public class Person
	{
		public string DisplayName { get; set; }

		public Picture Picture { get; set; }

		public string ImageUrl { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }

		public Location Address { get; set; }

		public string CityAndState {
			get {
				if (string.IsNullOrWhiteSpace (Address.city) || string.IsNullOrWhiteSpace (Address.state))
					return string.Empty;
				
				return Address.city.UppercaseFirst () + ", " + Address.state.UppercaseFirst ();
			}
		}

		public string Initials {
			get {
				return DisplayName.GetInitials ();
			}
		}

	}
}

