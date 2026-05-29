namespace DnDCombater.Models
{
	public class Character
	{
		public string Name { get; set; }
		public int HP { get; set; }
		public int AC { get; set; }
		public int Initiative { get; set; }
		public bool IsPlayer { get; set; }
	}
}
