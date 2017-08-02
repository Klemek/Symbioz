using System;

namespace Symbioz.RawData
{
    public class RawHandlerAttribute : Attribute
    {
        public short RawMessageId { get; set; }
        public RawHandlerAttribute(short rawmessageId)
        {
            this.RawMessageId = rawmessageId;
        }
    }
}
