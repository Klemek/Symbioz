using Symbioz.ORM;
using System.Collections.Generic;

namespace Symbioz.World.Records
{
    [Table("DungeonsIds", true)]
    public class DungeonsIdRecord : ITable
    {
        public static List<DungeonsIdRecord> DungeonsId = new List<DungeonsIdRecord>();
        public int Id;
        public string Name;
        public DungeonsIdRecord(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}