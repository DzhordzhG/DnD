
using System.Windows.Controls;

public static class NavigationService
{
	private static Stack<UserControl> _history = new Stack<UserControl>();

	public static ContentControl? MainContentControl { get; set; }

	public static void Navigate(UserControl newView)
	{
		if (MainContentControl == null)
			return;

		if (MainContentControl.Content is UserControl currentView)
		{
			_history.Push(currentView);
		}

		MainContentControl.Content = newView;
	}

	public static void GoBack()
	{
		if (MainContentControl == null || _history.Count == 0)
			return;

		var previous = _history.Pop();
		MainContentControl.Content = previous;
	}
}