using Symbioz.Utils;

namespace Symbioz.RawData.RawMessages
{
    public abstract class RawMessage
    {
        public abstract void Serialize(BigEndianWriter writer);
        public abstract void Deserialize(BigEndianReader reader);
    }
}
