using DndCombater.Data;
using DnDCombater.Commands;
using DnDCombater.Core.Models;
using DnDCombater.Models;
using DnDCombater.Registries;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace DnDCombater.ViewModels
{
    public class BattlemapCreatorViewModel : BaseViewModel
    {
		// private vars
		private int _nextId;

		private string? _battlemapName;

		private string? _battlemapSize = "1";

		private bool _isResizable;

		private string _sizeString;

		private bool _isSaving = false;

        private BitmapImage _battlemapPreview;


		// public vars
		public ICommand SelectImageCommand { get; }
		public ICommand SaveBattlemapCommand { get; }

		public BitmapImage? BattlemapPreview
		{
			get => _battlemapPreview;
			set
			{
				_battlemapPreview = value;
				OnPropertyChanged();
			}
		}

		public string? BattlemapSize
		{
			get
			{
				if(!_isSaving)
				{
					switch (_battlemapSize)
					{
						case "1":
							_sizeString = "Small (10x10)";
							break;
						case "2":
							_sizeString = "Medium (20x20)";
							break;
						case "3":
							_sizeString = "Large (30x30)";
							break;
						case "4":
							_sizeString = "Huge (40x40)";
							break;
						default:
							_sizeString = "Small (10x10)";
							break;
					}
					return _sizeString;
				}
				return _battlemapSize;
			}
			set
			{
				switch(value)
				{
					case "Small (10x10)":
						_battlemapSize = "1";
						break;
					case "Medium (20x20)":
						_battlemapSize = "2";
						break;
					case "Large (30x30)":
						_battlemapSize = "3";
						break;
					case "Huge (40x40)":
						_battlemapSize = "4";
						break;
					default:
						_battlemapSize = "1";
						break;
				}
				OnPropertyChanged();
			}
		}

		public string? BattlemapName
		{
			get => _battlemapName;
			set
			{
				_battlemapName = value;
				OnPropertyChanged();
			}
		}

		public bool IsResizable
		{
			get => _isResizable;
			set
			{
				_isResizable = value;
				OnPropertyChanged();

				OnPropertyChanged(nameof(IsNotResizable));
			}
		}


		// actions
		public event Action<Battlemap> BattlemapCreated;


		// constructor
		public BattlemapCreatorViewModel()
        {
			BattlemapPreview = new BitmapImage(new Uri("pack://application:,,,/Resources/Backgrounds/basic_battlemap.jpg", UriKind.Absolute));
			SelectImageCommand = new RelayCommand(SelectImage);
			SaveBattlemapCommand = new RelayCommand(SaveBattlemap);
		}


		// Commands
		private void SelectImage()
		{

			var dialog = new OpenFileDialog
			{
				Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
			};

			if (dialog.ShowDialog() == true)
			{
				BattlemapPreview = new BitmapImage(new Uri(dialog.FileName));
			}
		}
		private void SaveBattlemap()
		{
			using var db = new ApplicationDbContext();
			_isSaving = true;

			try
			{
				_nextId = db.Battlemaps.OrderByDescending(c => c.Id).Select(c => c.Id).First() + 1;
			}
			catch
			{
				_nextId = 1;
			}


			if (!int.TryParse(this.BattlemapSize, out var size))
			{
				return;
			}

			var battlemap = new Battlemap
			{
				Id = _nextId++,
				Name = this.BattlemapName ?? $"Battlemap {_nextId}",
				Size = size,
				Resizable = this.IsResizable,
				Image = Converter.ConvertToBytes(BattlemapPreview)
			};

			db.Battlemaps.Add(battlemap);
			db.SaveChanges();

			BattlemapCreated?.Invoke(battlemap);
		}

		public bool IsNotResizable
		{
			get => !_isResizable;
			set
			{
				IsResizable = !value;
			}
		}

	}
}
