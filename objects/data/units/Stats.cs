using WarGames.objects.data.units.weapons;

namespace WarGames.objects.data.units
{
	class Stats
	{
		public Stats()
		{
			//Set the minHealth to 0, cause that is standard.
			MinHealth = 0;
		}

		public int MaxHealth { get; set; }
		public int CurrentHealth { get; set; }

		public int AttackValue { get; set; }
		public int SpeedValue { get; set; }
		public int APValue { get; set; }
		public int MaxAPValue { get; set; }
		public Weapon Weapon { get; set; }
		public Item[] Inventory { get; set; }

		public Picture UnitPicture { get; set; }

		public enum Picture
		{
			INFANTERI,
			SHERMAN_TANK
		}
		/// <summary>
		/// Set to 0 as when Stats is initilaized.
		/// </summary>
		public int MinHealth { get; set; }
	}
}
