using System;
using SFML.Graphics;
using WarGames.objects.data.gameinterface;

namespace WarGames.objects.renderers.gameinterface
{
	class UnitPictureBoxRenderer : Drawable, IDisposable
	{
		private UnitPictureBox data;
		private RectangleShape frame;
		private Sprite curentPicture;

		public UnitPictureBoxRenderer(UnitPictureBox data)
		{
			this.data = data;
			frame = new RectangleShape(data.Scale);
			frame.Position = data.Position;
			frame.FillColor = data.FillColor;

			curentPicture = new Sprite(new Texture(128, 128));
			
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			if (data.PictureSprite != null)
				curentPicture = data.PictureSprite;
	
			target.Draw(frame);
			target.Draw(curentPicture);
		}

		public void Dispose()
		{
			frame.Dispose();
			curentPicture.Dispose();
		}
	}
}
