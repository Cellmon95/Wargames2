using System;
using SFML.Graphics;
using WarGames.objects.data.units;

namespace WarGames.objects.renderers.units
{
	class UnitRenderer:Drawable, IDisposable
	{
		private Unit data;
		private RectangleShape rectangleShape;

		public UnitRenderer(Unit data)
		{
			this.data = data;
			Unit = data;
			rectangleShape = new RectangleShape(data.Size);
			rectangleShape.Scale = data.Scale;
			rectangleShape.FillColor = data.FillColor;
			rectangleShape.Position = data.Position;
		}

		public virtual void Draw(RenderTarget target, RenderStates states)
		{
			rectangleShape.Position = data.Position;

			if (data.Selected)
			{
				rectangleShape.OutlineColor = Color.Yellow;
				rectangleShape.OutlineThickness = 2;
			}
			else
			{
				rectangleShape.OutlineColor = Color.Transparent;
			}
			target.Draw(rectangleShape);
		}

		public void Dispose()
		{
			rectangleShape.Dispose();
		}

		public Unit Unit { get; private set; }
	}
}
