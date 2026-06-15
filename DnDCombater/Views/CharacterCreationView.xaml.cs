using DndCombater.Data;
using DnDCombater.ViewModels;
using System.Windows.Controls;

namespace DnDCombater.Views
{
	/// <summary>
	/// Interaction logic for CharacterCreationView.xaml
	/// </summary>
	public partial class CharacterCreationView : UserControl
	{
		public CharacterCreationView(CharacterCreationViewModel ccvm)
		{
			InitializeComponent();
			DataContext = ccvm;
			using var db = new ApplicationDbContext();

			ccvm.CharacterCreated += (character) =>
			{
				NavigationService.Navigate(new MainMenu());
			};
		}
	}
}
