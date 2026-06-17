using DndCombater.Data;
using DnDCombater.Commands;
using DnDCombater.Views;
using System.Windows.Input;

namespace DnDCombater.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private string _title;
		public ICommand OpenCharacterCreatorCommand { get; }
		public ICommand ShowCharactersCommand { get; }
		public ICommand BattlemapCreatorCommand { get; }

		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			Title = "DnD Combater";
			OpenCharacterCreatorCommand = new RelayCommand(OpenCharacterCreator);
			ShowCharactersCommand = new RelayCommand(ShowCharacters);
			BattlemapCreatorCommand = new RelayCommand(OpenBattlemapCreator);
		}

		private void OpenCharacterCreator()
		{
			var vm = new CharacterCreationViewModel();
			NavigationService.Navigate(new CharacterCreationView(vm));
		}
		private void OpenBattlemapCreator()
		{
			var vm = new BattlemapCreatorViewModel();
			NavigationService.Navigate(new BattlemapCreatorView(vm));
		}

		private void ShowCharacters()
		{
			var vm = new CharacterListViewModel();
			NavigationService.Navigate(new CharacterListView(vm));
		}
	}
}
