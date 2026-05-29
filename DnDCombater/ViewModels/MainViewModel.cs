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

	}
}
