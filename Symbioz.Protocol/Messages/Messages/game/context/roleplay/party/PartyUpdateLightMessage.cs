


















// Generated on 06/04/2015 18:44:38
using System;
using System.Collections.Generic;
using System.Linq;
using Symbioz.DofusProtocol.Types;
using Symbioz.Utils;

namespace Symbioz.DofusProtocol.Messages
{

public class PartyUpdateLightMessage : AbstractPartyEventMessage
{

public const ushort Id = 6054;
public override ushort MessageId
{
    get { return Id; }
}

public uint id;
        public uint lifePoints;
        public uint maxLifePoints;
        public ushort prospecting;
        public byte regenRate;
        

public PartyUpdateLightMessage()
{
}

public PartyUpdateLightMessage(uint partyId, uint id, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate)
         : base(partyId)
        {
            this.id = id;
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.prospecting = prospecting;
            this.regenRate = regenRate;
        }
        

public override void Serialize(ICustomDataOutput writer)
{

base.Serialize(writer);
            writer.WriteVarUhInt(id);
            writer.WriteVarUhInt(lifePoints);
            writer.WriteVarUhInt(maxLifePoints);
            writer.WriteVarUhShort(prospecting);
            writer.WriteByte(regenRate);
            

}

public override void Deserialize(ICustomDataInput reader)
{

base.Deserialize(reader);
            id = reader.ReadVarUhInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            lifePoints = reader.ReadVarUhInt();
            if (lifePoints < 0)
                throw new Exception("Forbidden value on lifePoints = " + lifePoints + ", it doesn't respect the following condition : lifePoints < 0");
            maxLifePoints = reader.ReadVarUhInt();
            if (maxLifePoints < 0)
                throw new Exception("Forbidden value on maxLifePoints = " + maxLifePoints + ", it doesn't respect the following condition : maxLifePoints < 0");
            prospecting = reader.ReadVarUhShort();
            if (prospecting < 0)
                throw new Exception("Forbidden value on prospecting = " + prospecting + ", it doesn't respect the following condition : prospecting < 0");
            regenRate = reader.ReadByte();
            if ((regenRate < 0) || (regenRate > 255))
                throw new Exception("Forbidden value on regenRate = " + regenRate + ", it doesn't respect the following condition : (regenRate < 0) || (regenRate > 255)");
            

}


}


}