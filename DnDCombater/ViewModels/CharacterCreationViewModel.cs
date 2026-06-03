using DnDCombater.Commands;
using DnDCombater.Models;
using Microsoft.Win32;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DnDCombater.ViewModels
{
	public class CharacterCreationViewModel : BaseViewModel
	{
		private string _name;
		private int? _hp;
		private int? _ac;
		private int? _initiative;
		private int? _speed;
		private string _characterClass;
		private string? _subClass;
		private int _nextId = 1;
		private BitmapImage? _image;

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged();
			}
		}
		public int? HP
		{
			get => _hp;
			set
			{
				_hp = value;
				OnPropertyChanged();
			}
		}
		public int? AC
		{
			get => _ac;
			set
			{
				_ac = value;
				OnPropertyChanged();
			}
		}
		public int? Initiative
		{
			get => _initiative;
			set
			{
				_initiative = value;
				OnPropertyChanged();
			}
		}
		public int? Speed
		{
			get => _speed;
			set
			{
				_speed = value;
				OnPropertyChanged();
			}
		}
		public string CharacterClass
		{ 
			get => _characterClass;
			set
			{
				_characterClass = value;
				OnPropertyChanged();
			}
		}
		public string? Subclass
		{
			get => _subClass;
			set
			{
				_subClass = value;
				OnPropertyChanged();
			}
		}
		public BitmapImage? Image
		{
			get => _image;
			set
			{
				_image = value;
				OnPropertyChanged();
			}
		}

		public ICommand SaveCommand { get; }
		public ICommand UploadImageCommand { get; }

		public event Action<Character> CharacterCreated;

		public CharacterCreationViewModel()
		{
			SaveCommand = new RelayCommand(SaveCharacter);
			UploadImageCommand = new RelayCommand(UploadImage);
			Image = new BitmapImage(new Uri(
				"pack://application:,,,/Resources/Character Images/morgan.png",
				UriKind.Absolute));

		}

		private void SaveCharacter()
		{
			if (string.IsNullOrWhiteSpace(Name) || HP == 0 || AC == 0 || Initiative == 0 || Speed == 0 || string.IsNullOrWhiteSpace(CharacterClass))
			{
				return;
			}
			var character = new Character
			{
				Id = _nextId++,
				Name = this.Name,
				HP = this.HP ?? 10,
				AC = this.AC ?? 10,
				Initiative = this.Initiative ?? 0,
				Speed = this.Speed ?? 10,
				CharacterClass = this.CharacterClass,
				Subclass = this.Subclass ?? "None",
				CharacterImage = this.Image
			};

			CharacterCreated?.Invoke(character);
		}

		private void UploadImage()
		{

			var dialog = new OpenFileDialog
			{
				Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
			};

			if (dialog.ShowDialog() == true)
			{
				Image = new BitmapImage(new Uri(dialog.FileName));
			}

		}
	}
}