using Symbioz.Core.Startup;
using Symbioz.Providers.Maps;
using Symbioz.World.Records;
using System.Collections.Generic;

namespace Symbioz.Providers
{
    public class PlacementCellsProvider
    {
        [StartupInvoke("Maps Placement Fix", StartupInvokeType.Internal)]
        public static void FixPlacementCells()
        {
            List<MapRecord> maps = MapRecord.GetMapWithoutPlacementCells();
            foreach (MapRecord map in maps)
            {
                PlacementPattern pattern = new PlacementPattern(map);
                pattern.Effectuate();
                map.BlueCells = pattern.PlacementCells.BlueCells;
                map.RedCells = pattern.PlacementCells.RedCells;
            }
        }


    }
}
