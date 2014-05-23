using System;

namespace WarGames.interfaces
{
	/// <summary>
	/// The interface for all screens. 
	/// </summary>
	interface IScreen : IDisposable
	{
		void update();
		void draw();
	}
}
