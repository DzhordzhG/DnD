using DnDCombater.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnDCombater.Views
{
	/// <summary>
	/// Interaction logic for CharacterListView.xaml
	/// </summary>
	public partial class CharacterListView : Window
	{
		public CharacterListView(CharacterListViewModel vm)
		{
			InitializeComponent();
			DataContext = vm;
		}

		private void GridViewColumnHeader_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
		{

        }
    }
}
