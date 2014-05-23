using System;
using WarGames.core;
using WarGames.handlers;
using WarGames.interfaces;
using WarGames.objects.data;
using WarGames.objects.data.gameinterface;
using WarGames.objects.renderers;

namespace WarGames.screens
{
	class CombatScreen : IScreen
	{
		private Game game;
		private DataMaster dataMaster;
		private MasterRenderer masterRenderer;
		private UnitHandler unitHandler;
		private InterfaceHandler interfaceHandler;
		public CombatScreen(Game game)
		{
			this.game = game;

			dataMaster = new DataMaster(game);
			DataMaster = dataMaster;

			unitHandler = new UnitHandler(game, this);
			interfaceHandler = new InterfaceHandler(this);
			masterRenderer = new MasterRenderer(dataMaster);

		}

		public void update()
		{
			dataMaster.update();
			unitHandler.update();
			interfaceHandler.update();
		}


		public void draw()
		{
			game.stage.Draw(masterRenderer);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public DataMaster DataMaster { get; private set; }
		public InterfaceBar InterfaceBar { get; private set; }
		public UnitHandler UnitHandler { get { return unitHandler; } set { unitHandler = value; } }
	}
}
