using System.Diagnostics;
using SFML.Window;
using System;
using System.Collections.Generic;
using WarGames.objects.data.gameinterface;
using WarGames.objects.data.map;
using WarGames.objects.data.units;

namespace WarGames.objects.data
{
	/// <summary>
	/// The master of all data.
	/// </summary>
	class DataMaster
	{
		public Map map { get; set; }
		private WarGames.core.Game game;
		public DataMaster(WarGames.core.Game game)
		{
			this.game = game;

			//make sure that the map is as big as the screen is
			map = new Map(new Vector2i(
				(int)Math.Round((float)(game.stage.Size.X / 32)),
				(int)Math.Round((float)(game.stage.Size.Y / 32) - 4)
				));
			InterfaceBar = new InterfaceBar();
		}

		internal void update()
		{
			foreach (Unit unit in Units)
			{
				if (unit.Dead)
				{
					Units.Remove(unit);
				}

				unit.update();
			}

			InterfaceBar.update();
		}

		public List<Unit> Units { set; get; }
		public InterfaceBar InterfaceBar { get; set; }
	}
}
