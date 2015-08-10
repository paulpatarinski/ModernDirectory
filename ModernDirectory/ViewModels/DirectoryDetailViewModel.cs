using PropertyChanged;
using ModernDirectory.Models;

namespace ModernDirectory.ViewModels
{
	[ImplementPropertyChanged]
	public class DirectoryDetailViewModel
	{
		public DirectoryDetailViewModel (Person person)
		{
			Person = person;
		}

		public Person Person {
			get;
			set;
		}
	}
}

