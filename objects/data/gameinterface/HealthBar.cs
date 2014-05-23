using SFML.Graphics;
using SFML.Window;
using WarGames.objects.data.units;

namespace WarGames.objects.data.gameinterface
{
	class HealthBar : Bar
	{
		private Unit selectedUnit;

		public HealthBar() : base(Color.Red)
		{
			Position = new Vector2f(180, 525);
			Size = new Vector2f(180, 20);
			CurrentValue = 100;
		}
		/// <summary>
		/// The selected unit the healthbar is connected to.
		/// </summary>
		public Unit SelectedUnit
		{
			get
			{
				return selectedUnit;
			}

			set
			{
				selectedUnit = value;

				MaxValue = SelectedUnit.Stats.MaxHealth;
				MinValue = SelectedUnit.Stats.MinHealth;
				CurrentValue = SelectedUnit.Stats.CurrentHealth;
			}
		}

		public void update()
		{
			if (SelectedUnit != null)
			{
				CurrentValue = SelectedUnit.Stats.CurrentHealth;
			}
		}
	}
}
