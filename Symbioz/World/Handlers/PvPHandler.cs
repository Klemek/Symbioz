using Symbioz.DofusProtocol.Messages;
using Symbioz.Network.Clients;
using Symbioz.Network.Messages;

namespace Symbioz.World.Handlers
{
    public class PvPHandler
    {
        [MessageHandler]
        public static void SetEnlablePvP(SetEnablePVPRequestMessage message, WorldClient client)
        {
            client.Character.TooglePvPMode(message.enable);
        }
    }
}
