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
		public CharacterCreationView(CharacterCreationViewModel vm)
		{
			InitializeComponent();
			DataContext = vm;

			vm.CharacterCreated += (character) =>
			{
				NavigationService.Navigate(new MainMenu());
			};
		}
	}
}
