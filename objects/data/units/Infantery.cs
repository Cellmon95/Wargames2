using SFML.Graphics;
using SFML.Window;
using WarGames.objects.data.units.weapons;

namespace WarGames.objects.data.units
{
	class Infantery : Unit
	{	
		public Infantery()
		{
			Position = new Vector2f(200, 300);
			Size = new Vector2f(32, 32);
			FillColor = Color.Red;

			initStats();
		}

		private void initStats()
		{
			Stats = new Stats
			{
				MaxHealth = 100,
				CurrentHealth = 100,
				AttackValue = 0,
				Weapon = new M1Garand(),
				SpeedValue = 3,
				MaxAPValue = 8,
			};
			Stats.APValue = Stats.MaxAPValue;
			Stats.UnitPicture = Stats.Picture.INFANTERI;
		}

		override internal void update()
		{
			//Position = new Vector2f(Position.X, Position.Y);
		}


	}
}
