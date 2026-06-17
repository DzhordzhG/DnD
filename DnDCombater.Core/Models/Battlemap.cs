namespace DnDCombater.Core.Models
{
	public class Battlemap
	{
		public int Id { get; set; }

		public int Size { get; set; }

		public string Name { get; set; }

		public byte[] Image { get; set; }

		public bool Resizable { get; set; } = false;

		public DateTime CreatedAt { get; set; }
	}
}
