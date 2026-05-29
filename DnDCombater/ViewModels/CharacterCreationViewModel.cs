using DnDCombater.Commands;
using DnDCombater.Models;
using System.Windows.Input;

namespace DnDCombater.ViewModels
{
	public class CharacterCreationViewModel : BaseViewModel
	{
		private string _name;
		private int _hp;
		private int _ac;
		private string _statusMessage = "Creating character...";

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged();
			}
		}
		public int HP
		{
			get => _hp;
			set
			{
				_hp = value;
				OnPropertyChanged();
			}
		}
		public int AC
		{
			get => _ac;
			set
			{
				_ac = value;
				OnPropertyChanged();
			}
		}
		public string StatusMessage
		{
			get => _statusMessage;
			set
			{
				_statusMessage = value;
				OnPropertyChanged();
			}
		}

		public ICommand SaveCommand { get; }

		public event Action<Character> CharacterCreated;

		public CharacterCreationViewModel()
		{
			SaveCommand = new RelayCommand(SaveCharacter);
		}

		private void SaveCharacter()
		{
			if (string.IsNullOrWhiteSpace(Name) || HP == 0 || AC == 0)
			{
				this.StatusMessage = "Please fill in all fields.";
				return;
			}
			var character = new Character
			{
				Name = this.Name,
				HP = this.HP,
				AC = this.AC
			};

			CharacterCreated?.Invoke(character);
		}
	}
}