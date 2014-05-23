using SFML.Graphics;
using SFML.Window;

namespace WarGames.objects.data.map
{
	class Tile : Transformable
	{

		public enum TileType
		{
			VOID,
			GRASS,
			DIRT
		}

		public Tile(TileType tileType)
		{
			Size = new Vector2f(32, 32);
			Children = new Tile[8];
			Type = tileType;

			setTileType(tileType);
		}

		private void setTileType(TileType tileType)
		{
			switch (tileType)
			{
				case TileType.VOID:
					FillColor = Color.White;
					break;
				case TileType.GRASS:
					FillColor = Color.Green;
					BaseGvalue = 10;
					break;
				case TileType.DIRT:
					FillColor = new Color(51, 25, 00);
					BaseGvalue = 15;
					break;
				default:
					break;
			}
		}



		public Vector2f Size { get; private set; }

		public Color FillColor { get; private set; }

		public TileType Type { get; private set; }

		//pathfinding properties
		public Tile[] Children { get; set; }
		/// <summary>
		/// The tile closests to the target sourunded by this tile.
		/// </summary>
		public Tile Parent { get; set; }

		public int GValue { get; set; }

		public int FValue { get; set; }

		public int Hvalue { get; private set; }
		/// <summary>
		/// The base for the g value.
		/// </summary>
		public int BaseGvalue { get; private set; }

		internal void calculateFValue()
		{
			FValue = GValue + Hvalue;
		}

		internal void resetGFValue()
		{
			FValue = 0;
			GValue = BaseGvalue;
		}
	}
}
