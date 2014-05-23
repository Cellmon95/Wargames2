using SFML.Graphics;
using SFML.Window;

namespace WarGames.objects.data.gameinterface
{
	class Bar : Transformable
	{
		private int currentValue;
		private Vector2f contentSize;

		public Bar(Color contentColor, int maxValue = 100, int minValue = 0)
		{
			MaxValue = maxValue;
			MinValue = minValue;
			ContentColor = contentColor;

			BackroundColor = Color.Black;
			OutlineColor = new Color(43, 43, 43);
			OutlineThicknes = 5;
			contentSize = Size;
		}


		/// <summary>
		/// The maximum value the bar can have.
		/// </summary>
		public int MaxValue { get; protected set; }
		/// <summary>
		/// The minimum value the bar can have.
		/// </summary>
		public int MinValue { get; protected set; }
		/// <summary>
		/// The color of the content inside the bar.
		/// </summary>
		public Color ContentColor { get; protected set; }
		public Vector2f Size { get; protected set; }
		/// <summary>
		/// The current value of the bar.
		/// </summary>
		public int CurrentValue 
		{
			get
			{
				return currentValue;
			}

			set
			{
				contentSize = new Vector2f((Size.X / MaxValue) * value, Size.Y);
				currentValue = value;	
			}
		}

		public Color BackroundColor { get; set; }

		public int OutlineThicknes { get; set; }

		public Color OutlineColor { get; set; }

		public Vector2f ContentSize { get { return contentSize; } }
	}
}
