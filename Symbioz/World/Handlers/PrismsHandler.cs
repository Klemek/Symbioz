using Symbioz.DofusProtocol.Messages;
using Symbioz.DofusProtocol.Types;
using Symbioz.Network.Clients;
using Symbioz.Network.Messages;

namespace Symbioz.World.Handlers
{
    class PrismsHandler
    {
        [MessageHandler]
        public static void HandlePrismList(PrismsListRegisterMessage message, WorldClient client)
        {
            client.Send(new PrismsListMessage(new PrismSubareaEmptyInfo[0]));
        }
    }
}
