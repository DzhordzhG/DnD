using System;
using System.Collections.Generic;
using System.Text;

namespace DnDCombater.Models
{
	public class CharacterClass
	{
		public int ClassName { get; set; }

		public string? Description { get; set; }

		public string HitDice { get; set; }

		public (string, string) SavingThrowProficiencies { get; set; }

		public string[] WeaponProficiencies { get; set; }

		public string[] ArmorProficiencies { get; set; }

		public string[] ToolProficiencies { get; set; }

		public string[] SkillProficiencies { get; set; }


	}
}
