using Symbioz.DofusProtocol.Messages;
using Symbioz.Network.Clients;
using Symbioz.Network.Messages;

namespace Symbioz.World.Handlers
{
    class CosmeticHandler
    {
        [MessageHandler]
        public static void HandleTitleAndOrnamentsListRequest(TitlesAndOrnamentsListRequestMessage message, WorldClient client)
        {
            client.Send(new TitlesAndOrnamentsListMessage(client.Character.Record.KnownTiles, client.Character.Record.KnownOrnaments, client.Character.Record.ActiveTitle, client.Character.Record.ActiveOrnament));
        }
        [MessageHandler]
        public static void HandleOrnamentSelect(OrnamentSelectRequestMessage message, WorldClient client)
        {
            client.Character.SelectOrnament(message.ornamentId);
            client.Send(new OrnamentSelectedMessage(message.ornamentId));
        }
        [MessageHandler]
        public static void HandleTitleSelect(TitleSelectRequestMessage message, WorldClient client)
        {
            client.Character.SelectTitle(message.titleId);
            client.Send(new TitleSelectedMessage(message.titleId));
        }


    }
}
