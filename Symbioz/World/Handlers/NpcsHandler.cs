using Symbioz.DofusProtocol.Messages;
using Symbioz.Network.Clients;
using Symbioz.Network.Messages;
using Symbioz.Providers;
using Symbioz.World.Records;

namespace Symbioz.World.Handlers
{
    class NpcsHandler
    {
        [MessageHandler]
        public static void HandleNpcGenericAction(NpcGenericActionRequestMessage message, WorldClient client)
        {
            NpcSpawnRecord record = NpcSpawnRecord.GetNpcByContextualId(message.npcId);
            if (record != null)
                NpcsActionsProvider.Handle(client, record, message.npcActionId);
        }
        [MessageHandler]
        public static void HandleNpcDialogReply(NpcDialogReplyMessage message, WorldClient client)
        {
            NpcsRepliesProvider.Handle(client, NpcReplyRecord.GetNpcRepliesData(message.replyId));
        }
    }
}
