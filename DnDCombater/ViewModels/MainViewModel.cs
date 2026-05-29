namespace DnDCombater.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private string _title;

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
		}
	}
}
