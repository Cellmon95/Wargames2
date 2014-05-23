using SFML.Graphics;
using SFML.Window;
using WarGames.objects.data.units;

namespace WarGames.objects.data.gameinterface
{
	class InterfaceBar : Transformable
	{
		private Unit selectedUnit;

		public InterfaceBar()
		{
			Size = new Vector2f(800, 4 * 32);
			Position = new Vector2f(0, 640 - 32 * 4);
			FillColor = new Color(127, 127, 127);

			UnitPictureBox = new UnitPictureBox();
			HealthBar = new HealthBar();
			MoveButton = new MoveButton();
			AttackButton = new AttackButton();
		}

		public Unit SelectedUnit {
			get
			{
				return selectedUnit;
			}
			set
			{
				selectedUnit = value;
				showStats();
			}
		}

		private void showStats()
		{
			UnitPictureBox.SelectedUnit = selectedUnit;
			HealthBar.SelectedUnit = selectedUnit;
		}

		public Vector2f Size { get; private set; }
		public Color FillColor { get; private set; }
		public UnitPictureBox UnitPictureBox { get; private set; }
		public HealthBar HealthBar { get; private set; }

		public void update()
		{
			HealthBar.update();
		}

		public MoveButton MoveButton { get; set; }

		public AttackButton AttackButton { get; set; }
	}
}
