using Symbioz.ORM;
using System.Collections.Generic;

namespace Symbioz.World.Records
{
    [Table("Heads", true)]
    public class HeadRecord : ITable
    {
        public static List<HeadRecord> Heads = new List<HeadRecord>();

        public int Id;
        public short SkinId;
        public HeadRecord(int id, short skinid)
        {
            this.Id = id;
            this.SkinId = skinid;
        }

        public static short GetSkinFromCosmeticId(int cosmeticid)
        {
            return Heads.Find(x => x.Id == cosmeticid).SkinId;
        }
    }
}
