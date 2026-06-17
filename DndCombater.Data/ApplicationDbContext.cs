using DnDCombater.Core.Models;
using DnDCombater.Models;
using Microsoft.EntityFrameworkCore;

namespace DndCombater.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Character> Characters { get; set; }
		public DbSet<CharacterClass> CharacterClasses { get; set; }
		public DbSet<Battlemap> Battlemaps { get; set; }

		public string DbPath { get; }

		public ApplicationDbContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = Path.Join(path, "main.db");
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}
