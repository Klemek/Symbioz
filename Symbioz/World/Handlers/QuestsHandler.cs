using Symbioz.DofusProtocol.Messages;
using Symbioz.DofusProtocol.Types;
using Symbioz.Network.Clients;
using Symbioz.Network.Messages;

namespace Symbioz.World.Handlers
{
    class QuestsHandler
    {
        [MessageHandler]
        public static void HandleQuestListRequest(QuestListRequestMessage message, WorldClient client)
        {
            client.Send(new QuestListMessage(new ushort[0], new ushort[0], new QuestActiveInformations[0], new ushort[0]));
        }
    }
}
