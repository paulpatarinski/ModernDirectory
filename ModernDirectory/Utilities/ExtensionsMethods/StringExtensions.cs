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

			var initialsReg = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");

			var initialsFull = initialsReg.Replace (fullname, "$1");

			if (initialsFull.Length == 1)
				return initialsFull;

			return initialsFull.Substring (0,2);
		}
	}
}

