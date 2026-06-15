using DnDCombater.Models;
using DnDCombater.ViewModels;
using System.Windows;
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

			ccvm.CharacterCreated += (character) =>
			{
				NavigationService.Navigate(new MainMenu());
			};
		}
	}
}
