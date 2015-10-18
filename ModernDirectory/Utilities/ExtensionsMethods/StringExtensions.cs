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
		public static string GetInitials (this string fullname)
		{
			if (string.IsNullOrWhiteSpace (fullname))
				return string.Empty;

			var initialsReg = new Regex (@"(\b[a-zA-Z])[a-zA-Z]* ?");

			var initialsFull = initialsReg.Replace (fullname, "$1");

			if (initialsFull.Length == 1)
				return initialsFull;

			return initialsFull.Substring (0, 2);
		}

		/// <summary>
		/// Uppercases the first.
		/// http://www.dotnetperls.com/uppercase-first-letter
		/// </summary>
		/// <returns>The first.</returns>
		/// <param name="s">S.</param>
		public static string UppercaseFirst (this string s)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty (s)) {
				return string.Empty;
			}
			// Return char and concat substring.
			return char.ToUpper (s [0]) + s.Substring (1);
		}
	}
}

