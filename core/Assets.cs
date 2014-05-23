using SFML.Graphics;

namespace WarGames.core
{
	/// <summary>
	/// Keeps all the resources static. 
	/// </summary>
	class Assets
	{
		/// <summary>
		/// Load from the resources file.
		/// </summary>
		public static void load()
		{	
			InfantryText = new Texture("resources\\Infantry.jpg");
			ShermanTankText = new Texture("resources\\Tank_Sherman.jpg");
			ArialFont = new Font("resources\\fonts\\arial.ttf");
			
		}

		public static Font ArialFont { get; private set; }
		public static Texture InfantryText { get; private set; }
		public static Texture ShermanTankText { get; private set; }
	}
}
