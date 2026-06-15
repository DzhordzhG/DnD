namespace DnDCombater.Models
{
	public class Character
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string CharacterClass { get; set; }

		public string Subclass { get; set; }

		public int HP { get; set; }

		public int AC { get; set; }

		public int Initiative { get; set; }

		public int Speed { get; set; }

		public byte[]? CharacterImage { get; set; }
	}
}
