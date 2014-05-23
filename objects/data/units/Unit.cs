using System;
using SFML.Graphics;
using SFML.Window;

namespace WarGames.objects.data.units
{
	/// <summary>
	/// Abstract class to create the units.
	/// </summary>
	abstract class Unit : Transformable
	{
		protected Stats stats;
		internal virtual void update()
		{
		}

		public enum Types
		{
			INFANTERI
		}

		public Types Type { get; private set; }
		public Color FillColor { get; protected set; }
		public Boolean Selected { get; set; }
		public Vector2f Size { get; set; }
		public Stats Stats { get; set; }
		public bool Dead { get; set; }
	}
}
