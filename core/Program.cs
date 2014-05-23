using SFML.Graphics;
using SFML.Window;

namespace WarGames.core
{
	class Program
	{
		private static RenderWindow stage;
		private static Game game;

		static void Main(string[] args)
		{
			//init stage and input metadata
			stage = new RenderWindow(new VideoMode(800, 640), "WarGames");
			stage.SetFramerateLimit(60);

			//init game and start it
			game = new Game(stage);
			game.start();
		}
	}
}
