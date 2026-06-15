
using DndCombater.Data;
using DnDCombater.Commands;
using DnDCombater.Models;
using DnDCombater.Registries;
using DnDCombater.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

public class CharacterListViewModel : BaseViewModel
{
	private Character _selectedCharacter;
	private ApplicationDbContext _db;

	public Character SelectedCharacter
	{
		get => _selectedCharacter;
		set
		{
			_selectedCharacter = value;
			OnPropertyChanged();
			OnPropertyChanged(nameof(SelectedCharacterImage));
		}
	}

	public ObservableCollection<Character> Characters { get; set; }
	public ICommand DeleteCharacterCommand { get; }

	public CharacterListViewModel()
	{
		_db = new ApplicationDbContext();

		Characters = new ObservableCollection<Character>(GetCharacterList());

		DeleteCharacterCommand = new RelayCommand(DeleteCharacter);
	}

	public BitmapImage SelectedCharacterImage
	{
		get => Converter.ConvertToImage(SelectedCharacter?.CharacterImage);
	}

	public void DeleteCharacter()
	{
		var character = _db.Characters.FirstOrDefault(c => c.Id == SelectedCharacter.Id);

		_db.Remove(character);
		_db.SaveChanges();

		SelectedCharacter?.CharacterImage = null;
		Characters.Remove(SelectedCharacter);
		SelectedCharacter = null;
	}

	private List<Character> GetCharacterList()
	{
		return _db.Characters.OrderBy(c => c.Id).ToList();
	}
}