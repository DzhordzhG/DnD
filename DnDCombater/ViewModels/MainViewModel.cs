using DnDCombater.Commands;
using DnDCombater.Models;
using DnDCombater.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnDCombater.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private string _title;
		public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
		public ICommand OpenCharacterCreatorCommand { get; }
		public ICommand ShowCharactersCommand { get; }

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
		}

		private void OpenCharacterCreator()
		{
			var vm = new CharacterCreationViewModel();
			var window = new CharacterCreationWindow(vm);

			vm.CharacterCreated += character =>
			{
				Characters.Add(character);
			};

			window.ShowDialog();
		}
		private void ShowCharacters()
		{
			var vm = new CharacterListViewModel(Characters);
			var window = new CharacterListView(vm);
			window.ShowDialog();
		}
	}
}
