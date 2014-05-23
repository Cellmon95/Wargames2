using System;
using SFML.Graphics;
using SFML.Window;

namespace WarGames.objects.data.gameinterface
{
	internal class Button : Transformable
	{
		private Boolean selected;
		/// <summary>
		/// Creates a button without any text.
		/// </summary>
		/// <param name="position">The position the button is at.</param>
		/// <param name="size">The size of the button</param>
		public Button(Vector2f position, Vector2f size)
		{
			Position = position;
			Size = size;
			FillColor = Color.Black;
			OutlineColor = Color.Red;
			OutlineThicknes = 3;
		}
		/// <summary>
		/// Creates a button with text.
		/// </summary>
		/// <param name="position">The position the button is at.</param>
		/// <param name="size">The size of the button.</param>
		/// <param name="text">The text on the button</param>
		public Button(Vector2f position, Vector2f size, String text)
		{
			Position = position;
			Size = size;
			FillColor = new Color(60, 60, 60);
			OutlineColor = new Color(153, 153, 153);
			OutlineThicknes = 3;
			Text = text;
			TextColor = new Color(204, 204, 204);
		}

		public Vector2f Size { get; private set; }
		public String Text { set; get; }

		public Color FillColor { get; private set; }

		public Color OutlineColor { get; private set; }

		public float OutlineThicknes { get; private set; }

		public Color TextColor { get; private set; }

		public bool Selected
		{
			get { return selected; }

			set
			{
				selected = value;

				FillColor = selected ? new Color(40, 40, 40) : new Color(60, 60, 60);
			}
		}
	}
}