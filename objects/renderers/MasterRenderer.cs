using System;
using System.Collections.Generic;
using SFML.Graphics;
using WarGames.objects.data;
using WarGames.objects.data.units;
using WarGames.objects.renderers.gameinterface;
using WarGames.objects.renderers.map;
using WarGames.objects.renderers.units;

namespace WarGames.objects.renderers
{
	/// <summary>
	/// Master of the renderers.
	/// </summary>
	class MasterRenderer : Drawable, IDisposable
	{
		private DataMaster dataMaster;
		private MapRenderer mapRenderer;
		private InterfaceBarRenderer interfaceBarRenderer;
		private List<UnitRenderer> UnitRenderers;

		public MasterRenderer(DataMaster dataMaster)
		{
			this.dataMaster = dataMaster;

			UnitRenderers = new List<UnitRenderer>(dataMaster.Units.Count);

			mapRenderer = new MapRenderer(dataMaster.map);
			interfaceBarRenderer = new InterfaceBarRenderer(dataMaster.InterfaceBar);
			initUnitsRenderers();
		}

		/// <summary>
		/// Init the unitRenderers relative to the units
		/// </summary>
		private void initUnitsRenderers()
		{
			for (int i = 0; i < dataMaster.Units.Count; i++)
			{
				if (dataMaster.Units[i].GetType() == typeof(Infantery))
					UnitRenderers.Add(new InfanteryRenderer(dataMaster.Units[i] as Infantery));

				else if (dataMaster.Units[i].GetType() == typeof(Tank))
					UnitRenderers[i] = new TankRenderer(dataMaster.Units[i] as Tank);
			}
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			target.Draw(mapRenderer);
			for (int i = 0; i < UnitRenderers.Count; i++)
			{
				if (UnitRenderers[i].Unit.Dead)
				{
					//remove and dispose the element
					UnitRenderer tmpUnitRenderer = UnitRenderers[i];
					UnitRenderers.Remove(tmpUnitRenderer);
					tmpUnitRenderer.Dispose();
					tmpUnitRenderer = null;
				}

				else
				{
					target.Draw(UnitRenderers[i]);
				}
			}
			target.Draw(interfaceBarRenderer);
		}

		public void Dispose()
		{
			mapRenderer.Dispose();
		}
	}
}
