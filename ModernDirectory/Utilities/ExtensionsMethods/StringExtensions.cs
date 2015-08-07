using System.Text.RegularExpressions;

namespace ModernDirectory.Utilities.ExtensionsMethods
{
	public static class StringExtensions
	{
		/// <summary>
		/// Returns initials given a fullname 
		/// Source http://stackoverflow.com/questions/10820273/regex-to-extract-initials-from-name
		/// </summary>
		/// <returns>The initials.</returns>
		/// <param name="fullname">Fullname.</param>
		public static string GetInitials(this string fullname)
		{
			if (string.IsNullOrWhiteSpace (fullname))
				return string.Empty;

			var initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");

			return initials.Replace(fullname, "$1");
		}
	}
}

