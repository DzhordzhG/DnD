using DnDCombater.ViewModels;
using System.Windows;

namespace DnDCombater.Views
{
	/// <summary>
	/// Interaction logic for CharacterCreationWindow.xaml
	/// </summary>
	public partial class CharacterCreationWindow : Window
	{
		public CharacterCreationWindow(CharacterCreationViewModel ccvm)
		{
			InitializeComponent();
			DataContext = ccvm;

			ccvm.CharacterCreated += (character) =>
			{
				DialogResult = true;
				Close();
			};
		}
	}
}
