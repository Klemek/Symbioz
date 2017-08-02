using Symbioz.Core;
using Symbioz.ORM;
using System.Collections.Generic;

namespace Symbioz.World.Records
{
    [Table("Emotes")]
    public class EmoteRecord : ITable
    {
        public static List<EmoteRecord> Emotes = new List<EmoteRecord>();

        public byte Id;
        public int NameId;
        public string DefaultAnim;
        [Ignore]
        public string Name { get; set; }
        public bool IsAura;

        public EmoteRecord(byte id, int nameid, string defaultanim, bool isaura)
        {
            this.Id = id;
            this.NameId = nameid;
            this.Name = LangManager.GetText(nameid);
            this.IsAura = isaura;
        }

        public static EmoteRecord GetEmote(int id)
        {
            return Emotes.Find(x => x.Id == id);
        }
    }
}
