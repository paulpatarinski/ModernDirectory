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

		public string Initials {
			get {
				return DisplayName.GetInitials ();
			}
		}

	}
}

