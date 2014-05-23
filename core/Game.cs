using SFML.Graphics;
using WarGames.interfaces;
using WarGames.screens;

namespace WarGames.core
{
	class Game
	{
		public RenderWindow stage { get; set; }

		private IScreen curentScreen;

		public enum Screens
		{
			TEST_SCREEN
		}

		public Game(RenderWindow stage)
		{
			this.stage = stage;
			Assets.load();
		}

		public void start()
		{
			changeScreen(Screens.TEST_SCREEN);
			Input.Stage = stage;
			Input.addEventListeners();

			loop();
		}

		public void changeScreen(Screens screen)
		{
			if (curentScreen != null)
			{
				curentScreen.Dispose();
				curentScreen = null;
			}

			switch (screen)
			{
				case Screens.TEST_SCREEN:
					curentScreen = new CombatScreen(this);
					break;
				default:
					break;
			}
		}

		private void loop()
		{
			while (stage.IsOpen())
			{
				Input.dispatchEvents();

				update();

				Draw();

				Input.restore();
			}
		}

		private void update()
		{
			curentScreen.update();
		}

		private void Draw()
		{
			stage.Clear();
			curentScreen.draw();
			stage.Display();
		}
	}
}
