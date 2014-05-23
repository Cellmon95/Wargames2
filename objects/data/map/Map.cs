using System;
using SFML.Window;

namespace WarGames.objects.data.map
{
	class Map
	{
		public Tile[,] tiles { set; get; }
		Random rand;
		public Map(Vector2i mapSize)
		{
            //need to make the map one unit bigger for the void frame
            mapSize.X++;
            mapSize.Y++;
			Size = new Vector2f(mapSize.X * 32, mapSize.Y * 32);
			Position = new Vector2f(-32, -32);

			tiles = new Tile[mapSize.X + 2, mapSize.Y + 2];
			rand = new Random();

			randomiseMap();
			setTileChildren();
		}

        /// <summary>
        /// Sets the children to every tile. The tile children is the tiles that
        /// surrounds the target tile.  
        /// </summary>
		private void setTileChildren()
		{
			for (int x = 1; x < tiles.GetLength(0) - 1; x++)
			{
				for (int y = 1; y < tiles.GetLength(1) - 1; y++)
				{
					//left
					tiles[x, y].Children[0] = tiles[x - 1, y];
					//top left
					tiles[x, y].Children[1] = tiles[x - 1, y - 1];
					//top
					tiles[x, y].Children[2] = tiles[x, y - 1];
					//top right
					tiles[x, y].Children[3] = tiles[x + 1, y - 1];
					//right
					tiles[x, y].Children[4] = tiles[x + 1, y];
					//bottom rigth
					tiles[x, y].Children[5] = tiles[x + 1, y + 1];
					//bottom
					tiles[x, y].Children[6] = tiles[x, y + 1];
					//bottom left
					tiles[x, y].Children[7] = tiles[x - 1, y + 1];
				}
			}
		}

        /// <summary>
        /// Makes the map random.
        /// </summary>
		private void randomiseMap()
		{
			int tmpNum = 0;
			for (int x = 0; x < tiles.GetLength(0); x++)
			{
				for (int y = 0; y < tiles.GetLength(1); y++)
				{
					if (x == 0 || x == tiles.GetLength(0) - 1)
					{
                        tiles[x, y] = null;
					}

					else if (y == 0 || y == tiles.GetLength(1) - 1)
					{
                        tiles[x, y] = null;
					}

					else
					{
						tmpNum = rand.Next(0, 100);

						if (tmpNum <= 80)
							tiles[x, y] = new Tile(Tile.TileType.GRASS);
						else if (tmpNum >= 80 && tmpNum <= 100)
							tiles[x, y] = new Tile(Tile.TileType.DIRT);
                        //set the position
                        tiles[x, y].Position = new SFML.Window.Vector2f(x * 32 + Position.X, y * 32 + Position.Y);
					}
				}
			}
		}

		public Vector2f Size { get; private set; }

		public Vector2f Position { get; private set; }

		internal Tile getTileByPosition(Vector2f position)
		{
			return tiles[(int)((position.X - Position.X) / 32), (int)((position.Y - Position.Y)/ 32)];
		}

        /// <summary>
        /// Resets the tiles parents and GF values.
        /// </summary>
		internal void resetTiles()
		{
			for (int x = 0; x < tiles.GetLength(0); x++)
			{
				for (int y = 0; y < tiles.GetLength(1); y++)
				{
					if(tiles[x, y] != null)
					{
						tiles[x, y].resetGFValue();
						tiles[x, y].Parent = null;
					}
				}
			}
		}
	}
}
