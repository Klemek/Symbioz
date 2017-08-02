using Symbioz.ORM;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Symbioz.World.Records.Maps
{
    [Table("MapsTriggers", true)]
    class MapTriggerRecord : ITable
    {
        static ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
        public static List<MapTriggerRecord> MapsTriggers = new List<MapTriggerRecord>();

        [Primary]
        public int Id;
        public int MapId;
        public int CellId;
        public int TriggerType;
        public int TargetMapId;
        public int TargetCellId;

        public MapTriggerRecord(int id, int mapid, int cellid, int triggertype, int targetmapid, int targetcellid)
        {
            this.Id = id;
            this.MapId = mapid;
            this.CellId = cellid;
            this.TriggerType = triggertype;
            this.TargetMapId = targetmapid;
            this.TargetCellId = targetcellid;
        }

        public static MapTriggerRecord GetMapTrigger(int id)
        {
            return MapsTriggers.Find(x => x.Id == id);
        }

        public static List<MapTriggerRecord> GetMapTriggerByMap(int mapid)
        {
            return MapsTriggers.FindAll(x => x.MapId == mapid);
        }

        public static int PopNextId()
        {
            Locker.EnterReadLock();
            try
            {
                var ids = MapsTriggers.ConvertAll<int>(x => x.Id);
                ids.Sort();
                return ids.Count == 0 ? 1 : ids.Last() + 1;
            }
            finally
            {
                Locker.ExitReadLock();
            }
        }
    }
}
