using SFML.Window;
using System;
using System.Collections.Generic;
using WarGames.objects.data.map;

namespace WarGames.objects.data
{
	class Pathfinder
	{
		private readonly List<Tile> openList;
		private readonly List<Tile> closeList;
		private readonly Map map;

		public Pathfinder(Map map)
		{
			this.map = map;
			openList = new List<Tile>();
			closeList = new List<Tile>();
		}

		/// <summary>
		/// Calculates a straigt path betwen two points like a line. 
		/// </summary>
		public float calculateStraightPath(Vector2f start, Vector2f target)
		{
			//calculate the distance using the distance formula
			float tmpDistance = (float)Math.Sqrt(Math.Pow(target.X - start.X, 2) + Math.Pow(target.Y - start.Y, 2));
			tmpDistance = (float)Math.Round(tmpDistance);

			return tmpDistance;

			/*//if the target is att the same row. The just calculate it manhattan style
			if (start.X == target.X || start.Y == target.Y)
			{
				return Math.Abs(start.X - target.X) + Math.Abs(start.Y - target.Y);
			}
			
			//otherwise you calculate it manhattan style but split it in half. 
			//in this way you get estimated straigt path cost.
			else
			{
				return (Math.Abs(start.X - target.X) + Math.Abs(start.Y - target.Y)) / 2;
			}*/
		}

		public int calculateSmallestPath(Tile start, Tile target)
		{
			reset();

			if (target == start)
				return 0;

			StartingTile = start;
			TargetTile = target;
			//The first checking tile is the starting tile
			CheckingTile = StartingTile;

			while (!FoundTarget)
			{
				findPath();
			}

			//Console.WriteLine(TargetTile.FValue);
			return traceBack();
		}
		/// <summary>
		/// Find the path betwen the Starting tile and TargetTile
		/// </summary>
		private void findPath()
		{
			//check all the children AKA the sourunding tiles
			foreach (Tile t in CheckingTile.Children)
			{
				determenTileValue(CheckingTile, t);
			}

			if (FoundTarget) return;

			closeList.Add(CheckingTile);
			openList.Remove(CheckingTile);

			CheckingTile = getSmallestFValueTile();
		}

		
		private void determenTileValue(Tile currentTile, Tile testingTile)
		{
			if (testingTile == null)
			{
				return;
			}
			//check if we have found the target
			if (testingTile == TargetTile)
			{
				testingTile.Parent = currentTile;
				FoundTarget = true;
				return;
			}

			if (!closeList.Contains(testingTile))
			{
				if (openList.Contains(testingTile))
				{
					int newGCost = currentTile.GValue + currentTile.BaseGvalue;

					if (newGCost < testingTile.GValue)
					{
						testingTile.Parent = currentTile;
						testingTile.GValue = newGCost;
						testingTile.calculateFValue();
					}
				}

				else
				{
					testingTile.Parent = currentTile;
					testingTile.GValue = currentTile.GValue + currentTile.BaseGvalue;
					testingTile.calculateFValue();
					openList.Add(testingTile);
				}
			}
		}

		/// <summary>
		/// Sorts the list with a insertion sort
		/// </summary>
		/// <returns></returns>
		private Tile getSmallestFValueTile()
		{
			Console.WriteLine(openList.Count);
			if (openList.Count > 0)
			{
				for (int i = 1; i < openList.Count; i++)
				{
					Tile newValue = openList[i];
					int j = i;
					while (j > 0 && openList[j - 1].FValue > newValue.FValue)
					{
						openList[j] = openList[j - 1];
						j--;
					}
					openList[j] = newValue;
				}
				return openList[0];
			}
			return null;
		}


		/// <summary>
		/// Trace back the path and returns the number of steps
		/// </summary>
		/// <returns></returns>
		private int traceBack()
		{
			Tile tile = TargetTile;
			int count = -1;

			do
			{
				tile = tile.Parent;
				count++;
			}
			while (tile != null);

			return count;
		}
		/// <summary>
		/// Resets everything.
		/// </summary>
		private void reset()
		{
			map.resetTiles();
			openList.Clear();
			closeList.Clear();
			FoundTarget = false;
			TargetTile = null;
		}
		public Tile CheckingTile { get; private set; }
		public Tile StartingTile { get; private set; }
		public Tile TargetTile { get; private set; }
		public bool FoundTarget { get; private set; }
	}
}
