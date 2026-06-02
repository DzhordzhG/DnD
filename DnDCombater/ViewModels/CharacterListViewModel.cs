
using DnDCombater.Models;
using DnDCombater.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

public class CharacterListViewModel : BaseViewModel
{
	private Character _selectedCharacter;

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

	public ObservableCollection<Character> Characters { get; }

	public CharacterListViewModel(ObservableCollection<Character> characters)
	{
		Characters = characters;
	}

	public BitmapImage SelectedCharacterImage
	{
		get => SelectedCharacter?.CharacterImage;
	}

}