using SFML.Graphics;

namespace WarGames.objects.data.units
{
	class Tank : Unit
	{
		public Tank()
		{
			Size = new SFML.Window.Vector2f(32, 32);
			FillColor = Color.Black;

			initStats();
		}

		private void initStats()
		{
			Stats = new Stats
			{
				MaxHealth = 10,
				AttackValue = 8,
				SpeedValue = 5,
				UnitPicture = Stats.Picture.SHERMAN_TANK
			};
		}
	}
}
