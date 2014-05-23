using WarGames.screens;
using WarGames.core;
using WarGames.objects.data.gameinterface;
namespace WarGames.handlers
{
	/// <summary>
	/// Handles the interface.
	/// </summary>
	class InterfaceHandler
	{
		private readonly CombatScreen screen;
		private MoveButton moveButton;
		private Button curentSelectedButton;
 
		public InterfaceHandler(CombatScreen screen)
		{
			this.screen = screen;

			moveButton = screen.DataMaster.InterfaceBar.MoveButton;
			attackButton = screen.DataMaster.InterfaceBar.AttackButton;
		}

		public void update()
		{
			if (Input.checkIfPressed(moveButton.Position, moveButton.Size))
				selectButtonAndStatus(moveButton, UnitHandler.UnitStatus.MOVE);
			else if(Input.checkIfPressed(attackButton.Position, attackButton.Size))
				selectButtonAndStatus(attackButton, UnitHandler.UnitStatus.ATTACK);
		}

		/// <summary>
		/// This method make sure that you can only select one button att a time and
		/// also make so that when you select a button the button before will 
		/// deselect.
		/// </summary>
		/// <param name="selectedButton"></param>
		/// <param name="status"></param>
		private void selectButtonAndStatus(Button selectedButton, UnitHandler.UnitStatus status)
		{
			if (curentSelectedButton == null)
			{
				curentSelectedButton = selectedButton;
				curentSelectedButton.Selected = true;
				screen.UnitHandler.CurrentUnitStatus = status;
			}
			else if (selectedButton == curentSelectedButton)
			{
				curentSelectedButton.Selected = false;
				curentSelectedButton = null;
				screen.UnitHandler.CurrentUnitStatus = UnitHandler.UnitStatus.NONE;
			}
			else if (curentSelectedButton != null)
			{
				curentSelectedButton.Selected = false;
				curentSelectedButton = selectedButton;
				curentSelectedButton.Selected = true;
				screen.UnitHandler.CurrentUnitStatus = status;
			}

		}

		public AttackButton attackButton { get; set; }
	}
}
