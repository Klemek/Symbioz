using Symbioz.DofusProtocol.Messages;
using Symbioz.Network.Clients;
using Symbioz.Network.Servers;
using Symbioz.ORM;
using System.Collections.Generic;

namespace Symbioz.World.Records.Alliances
{
    [Table("GuildsAlliances", true)]
    public class GuildAllianceRecord : ITable
    {

        public static List<GuildAllianceRecord> GuildsAlliances = new List<GuildAllianceRecord>();

        [Primary]
        public int GuildId;
        public int AllianceId;

        public GuildAllianceRecord(int guildId, int allianceId)
        {
            this.GuildId = guildId;
            this.AllianceId = allianceId;
        }

        public void SendToMembers(Message message)
        {
            List<WorldClient> members = WorldServer.Instance.GetAllClientsOnline().FindAll(x => x.Character.GetGuild().Id == GuildId);
            foreach (WorldClient member in members)
            {
                member.Send(message);
            }
        }

        public static GuildAllianceRecord GetCharacterAlliance(int guildId)
        {
            return GuildsAlliances.Find(x => x.GuildId == guildId);
        }
    }
}
