using System;
using SFML.Graphics;
using WarGames.objects.data.map;

namespace WarGames.objects.renderers.map
{
	class MapRenderer : Drawable, IDisposable
	{
		private readonly Map data;
		private readonly TileRenderer[,] tilesRenderers;
		public MapRenderer(Map data)
		{
			this.data = data;
			tilesRenderers = new TileRenderer[data.tiles.GetLength(0) - 1, data.tiles.GetLength(1) - 1];
			createTileRenderers();
		}

		private void createTileRenderers()
		{
			for (int x = 0; x < data.tiles.GetLength(0); x++)
			{
				for (int y = 0; y < data.tiles.GetLength(1); y++)
				{
					if (data.tiles[x, y] != null)
						tilesRenderers[x, y] = new TileRenderer(data.tiles[x, y]);
				}
			}
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			for (int x = 0; x < tilesRenderers.GetLength(0); x++)
			{
				for (int y = 0; y < tilesRenderers.GetLength(1); y++)
				{
					if (tilesRenderers[x, y] != null)
						target.Draw(tilesRenderers[x, y]);
				}
			}
		}

		public void Dispose()
		{
			foreach (var t in tilesRenderers)
			{
				t.Dispose();
			}
		}
	}
}
