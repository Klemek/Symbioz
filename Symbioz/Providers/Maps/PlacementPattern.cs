﻿using Symbioz.World.Records;
using System.Collections.Generic;
using System.Linq;

namespace Symbioz.Providers.Maps
{
    public class PlacementPattern
    {
        public MapRecord Map { get; set; }
        public PlacementCells PlacementCells { get; set; }
        public PlacementPattern(MapRecord map)
        {
            this.PlacementCells = new PlacementCells();
            this.Map = map;
        }
        public List<short> GetRandomPlacementCells(List<short> existingcells)
        {
            List<short> results = new List<short>();
            List<short> possibleRandom = Map.WalkableCells;
            existingcells.ForEach(x => possibleRandom.Remove(x));
            for (short i = 0; i < 12; i++)
            {
                possibleRandom.Remove(i);
                if (possibleRandom.Count > 0)
                    results.Add(possibleRandom.Random<short>());
                else
                    return null;
            }
            return results;
        }
        public bool AllCellsExist(List<short> cells, List<short> reference)
        {
            if (cells.All(x => reference.Contains(x)))
                return true;
            else
                return false;
        }
        public void Effectuate()
        {
            PlacementCells.RedCells = GetRandomPlacementCells(new List<short>());
            PlacementCells.BlueCells = GetRandomPlacementCells(PlacementCells.RedCells);
        }
    }
    public class PlacementCells
    {
        public List<short> BlueCells = new List<short>();
        public List<short> RedCells = new List<short>();
    }
}
