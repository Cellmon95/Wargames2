using SFML.Graphics;
using System;
using WarGames.core;
using WarGames.objects.data.gameinterface;

namespace WarGames.objects.renderers.gameinterface
{
	class ButtonRenderer : Drawable, IDisposable
	{
		private RectangleShape body;
		private Text text;
		private Button data;

		public ButtonRenderer(Button data)
		{
			this.data = data;
			body = new RectangleShape
			{
				Position = data.Position,
				Size = data.Size,
				FillColor = data.FillColor,
				OutlineColor = data.OutlineColor,
				OutlineThickness = data.OutlineThicknes
			};

			text = new Text(data.Text, Assets.ArialFont)
			{
				Position = new SFML.Window.Vector2f(data.Position.X + data.Size.X/2 - 20, data.Position.Y - 3),
				CharacterSize = 18,
				Color = data.TextColor
			};
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			body.FillColor = data.FillColor;

			target.Draw(body);
			target.Draw(text);
		}

		public void Dispose()
		{
			body.Dispose();
			text.Dispose();
		}
	}
}
