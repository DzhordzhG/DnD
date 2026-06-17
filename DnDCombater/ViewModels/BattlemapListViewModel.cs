using DndCombater.Data;
using DnDCombater.Commands;
using DnDCombater.Core.Models;
using DnDCombater.Registries;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DnDCombater.ViewModels
{
	public class BattlemapListViewModel : BaseViewModel
	{
		private Battlemap _selectedMap;
		private ApplicationDbContext _db;

		public Battlemap SelectedMap
		{
			get => _selectedMap;
			set
			{
				_selectedMap = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(SelectedMapImage));
			}
		}

		public ObservableCollection<Battlemap> Battlemaps { get; set; }
		public ICommand DeleteMapCommand { get; }

		public BattlemapListViewModel()
		{
			_db = new ApplicationDbContext();

			Battlemaps = new ObservableCollection<Battlemap>(GetBattlemapList());
			DeleteMapCommand = new RelayCommand(DeleteMap);
		}

		public BitmapImage SelectedMapImage
		{
			get => Converter.ConvertToImage(SelectedMap?.Image);
		}

		public void DeleteMap()
		{
			var map = _db.Battlemaps.FirstOrDefault(m => m.Id == SelectedMap.Id);

			_db.Remove(map);
			_db.SaveChanges();

			SelectedMap?.Image = null;
			Battlemaps.Remove(SelectedMap);
			SelectedMap = null;
		}

		private List<Battlemap> GetBattlemapList()
		{
			return _db.Battlemaps.OrderBy(b => b.Id).ToList();
		}
	}
}
