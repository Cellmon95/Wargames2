using SFML.Graphics;
using WarGames.objects.data.gameinterface;

namespace WarGames.objects.renderers.gameinterface
{
	class BarRenderer : Drawable
	{
		private readonly Bar data;
		private RectangleShape background;
		private RectangleShape content;

		public BarRenderer(Bar data)
		{
			this.data = data;
			background = new RectangleShape(data.Size);
			background.FillColor = data.BackroundColor;
			background.OutlineThickness = data.OutlineThicknes;
			background.OutlineColor = data.OutlineColor;
			background.Position = data.Position;
			background.Size = data.Size;

			content = new RectangleShape();
			content.FillColor = data.ContentColor;
			content.Position = new SFML.Window.Vector2f(data.Position.X, data.Position.Y);
			content.Size = new SFML.Window.Vector2f(data.Size.X -40, data.Size.Y);
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			content.Size = data.ContentSize;
			target.Draw(background);
			target.Draw(content);
		}
	}
}
