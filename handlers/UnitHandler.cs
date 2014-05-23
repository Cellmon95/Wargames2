using SFML.Window;
using System;
using System.Collections.Generic;
using WarGames.core;
using WarGames.objects.data;
using WarGames.objects.data.units;
using WarGames.screens;

namespace WarGames.handlers
{
	struct Vector3
	{
		private int x;
		private int y;
		private int z;

		public Vector3(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public int X { set { x = value; } get { return x; } }

		public int Y { set { y = value; } get { return y; } }

		public int Z { set { z = value; } get { return z; } }
	}
	class UnitHandler
	{
		private Game game;
		private List<Unit> units;
		private Random rand;
		private readonly CombatScreen screen;
		private Unit selectedUnit;
		private Pathfinder pathfinder;

		private const int TILE_SIZE = 32;

		public UnitHandler(Game game, CombatScreen screen)
		{
			this.game = game;
			this.screen = screen;

			units = new List<Unit>();
			rand = new Random();

			pathfinder = new Pathfinder(screen.DataMaster.map);

			//Fill units list with infantery.
			for (int i = 0; i < 6; i++)
			{
				units.Add(new Infantery());
				units[i].Position = new SFML.Window.Vector2f(
					(float)Math.Round((double)rand.Next(0, 800/32)) * 32,
					(float)Math.Round((double)rand.Next(0, 640 / 32)) * 32);
			}
			screen.DataMaster.Units = units;	
		}

		public void update()
		{
			selectNextUnit();

			if (selectedUnit != null)
			{
				switch (CurrentUnitStatus)
				{
					case UnitStatus.MOVE:
						moveSelectedUnit();
						break;

					case UnitStatus.ATTACK:
						shootAtTarget();
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Selects the next unit if the player have clicked another unit
		/// and the unit is in the NONE status.
		/// </summary>
		private void selectNextUnit()
		{
			for (int i = 0; i < units.Count; i++)
			{
				if (CurrentUnitStatus == UnitStatus.NONE)
				{
					if (Input.checkIfClicked(units[i].Position, units[i].Size))
					{
						if (selectedUnit != null)
							selectedUnit.Selected = false;

						units[i].Selected = true;
						selectedUnit = units[i];
						screen.DataMaster.InterfaceBar.SelectedUnit = units[i];
					}
				}
			}
		}

		private void moveSelectedUnit()
		{
			/*if (Input.hoverAtPosition())
			{
			}*/

			if (Input.checkIfPressed(screen.DataMaster.map.Position, screen.DataMaster.map.Size))
			{
				int smallesPath = pathfinder.calculateSmallestPath(
					screen.DataMaster.map.getTileByPosition(selectedUnit.Position),
					screen.DataMaster.map.getTileByPosition(Input.ClickedPos));

				if ( smallesPath <= selectedUnit.Stats.APValue)
				{
					//subtrakt move points from the ap value
					selectedUnit.Stats.APValue -= smallesPath;
					
					//move the unit
					selectedUnit.Position = new Vector2f(
						(float)((int)Input.ClickedPos.X / 32) * 32,
						(float)((int)Input.ClickedPos.Y / 32) * 32);
					Console.WriteLine("You steped {0} steps", smallesPath);
				}
			}
		}

		private void shootAtTarget()
		{
			for (int i = 0; i < units.Count; i++)
			{
				Unit unit = units[i];

				//Check if the player have clicked any unit
				if (Input.checkIfPressed(unit.Position, unit.Size))
				{
					//check the distance
					float tmpDistance = pathfinder.calculateStraightPath(selectedUnit.Position, unit.Position);

					if (tmpDistance < 200)
					{
						unit.Stats.CurrentHealth -= selectedUnit.Stats.Weapon.Strength;

						checkIfDead(unit);
						Console.WriteLine("Hit were it hurt!");
					}
					else
					{
						Console.WriteLine("Can't hit that far.");
					}
				}
			}
		}

		/// <summary>
		/// Check if the health is smaller min health. If so then declare the unit dead.
		/// </summary>
		/// <param name="unit">The unit you wana check</param>
		private void checkIfDead(Unit unit)
		{
			if (unit.Stats.CurrentHealth <= 0)
			{
				units.Remove(unit);

				unit.Dispose();
				unit.Dead = true;
				unit = null;
			}
		}

		/// <summary>
		/// Change unit status. Status represent what the unit can do. If a unit can shoot it is in shooting status.
		/// </summary>
		public UnitStatus CurrentUnitStatus { get; set; }

		public enum UnitStatus
		{
			NONE,
			MOVE,
			ATTACK
		}
	}
}
