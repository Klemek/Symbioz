using Symbioz.ORM;
using System.Collections.Generic;

namespace Symbioz.World.Records.Maps
{
    [Table("MapsTip")]
    public class MapTipRecord : ITable
    {
        public static List<MapTipRecord> MapsTips = new List<MapTipRecord>();

        public int MapId;
        public string Tip;

        public MapTipRecord(int mapid, string tip)
        {
            this.MapId = mapid;
            this.Tip = tip;
        }

        public static MapTipRecord GetMapTip(int mapid)
        {
            return MapsTips.Find(x => x.MapId == mapid);
        }
    }
}
