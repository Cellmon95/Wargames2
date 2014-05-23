using System;
using SFML.Graphics;
using WarGames.objects.data.map;

namespace WarGames.objects.renderers.map
{
	class TileRenderer : Drawable, IDisposable
	{
		private Tile data;
		private RectangleShape rectangleShape;
		public TileRenderer(Tile data)
		{
            this.data = data;
			rectangleShape = new RectangleShape();
			rectangleShape.Size = this.data.Size;
			rectangleShape.FillColor = data.FillColor;
		}
		public void Draw(RenderTarget target, RenderStates states)
		{
			rectangleShape.Position = data.Position;
			target.Draw(rectangleShape);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
