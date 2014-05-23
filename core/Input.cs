using System;
using SFML.Window;
namespace WarGames.core
{
	/// <summary>
	/// Handles all the input static.
	/// </summary>
	class Input
	{
		public static void addEventListeners()
		{
			if (Stage == null)
			{
				throw new Exception { };
			}

			Stage.Closed += Stage_Closed;
			Stage.MouseButtonPressed += Stage_MouseButtonPressed;
			Stage.MouseButtonReleased += Stage_MouseButtonReleased;
		}

		static void Stage_MouseButtonReleased(object sender, MouseButtonEventArgs e)
		{
			Clicked = false;
		}

		static void Stage_Closed(object sender, EventArgs e)
		{
			Stage.Close();
		}

		static void Stage_MouseButtonPressed(object sender, MouseButtonEventArgs e)
		{
			Clicked = true;
			ClickedPos = new Vector2f(e.X, e.Y);
			MousePressed = true;
			Console.WriteLine(" Clicked Pos X:{0} Y:{1}", e.X, e.Y);
		}

		public static bool checkIfClicked(Vector2f position, Vector2f size)
		{
			if (Input.Clicked)
			{
				if (Input.ClickedPos.X >= position.X && Input.ClickedPos.X <= position.X + size.X)
				{
					if (Input.ClickedPos.Y >= position.Y && Input.ClickedPos.Y <= position.Y + size.Y)
					{
						return true;
					}
				}
			}

			return false;
		}

		public static Boolean checkIfPressed(Vector2f position, Vector2f size)
		{
			if (Input.MousePressed)
			{
				if (Input.ClickedPos.X >= position.X && Input.ClickedPos.X <= position.X + size.X)
				{
					if (Input.ClickedPos.Y >= position.Y && Input.ClickedPos.Y <= position.Y + size.Y)
					{
						return true;
					}
				}
			}

			return false;
		}

		public static void dispatchEvents()
		{
			Stage.DispatchEvents();
		}

		public static Boolean Clicked { get; private set; }
		public static Boolean MousePressed { get; internal set; }
		public static Vector2f ClickedPos { get; private set; }

		public static SFML.Graphics.RenderWindow Stage { get; set; }

		internal static void restore()
		{
			MousePressed = false;
		}
	}
}
