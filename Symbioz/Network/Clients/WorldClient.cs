﻿using Symbioz.DofusProtocol.Messages;
using Symbioz.Network.Servers;
using Symbioz.World.Models;
using Symbioz.World.Records;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Symbioz.Network.Clients
{
    public class WorldClient : DofusClient
    {
        public Character Character { get; set; }

        public List<CharacterRecord> Characters { get; set; }

        public WorldClient(Socket socket) : base(socket)
        {
            this.SSyncClient.OnClosed += SSyncClient_OnClosed;
            Send(new HelloGameMessage());
        }

        void SSyncClient_OnClosed()
        {
            if (Character != null)
                Character.Dispose();
            WorldServer.Instance.RemoveClient(this);
        }

    }
}
