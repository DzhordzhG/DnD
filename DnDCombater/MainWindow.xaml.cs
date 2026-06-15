using DnDCombater.ViewModels;
using DnDCombater.Views;
using System.Windows;

namespace DnDCombater
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			MainContent.Content = new MainMenu();

			NavigationService.MainContentControl = MainContent;
			NavigationService.Navigate(new MainMenu());
		}
		private void Back_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}