using Symbioz.World.Models.Fights.Fighters;
using System;

namespace Symbioz.World.Models.Fights.Marks
{
    public class InteractionAttribute : Attribute
    {
        public FighterEventType EventType { get; set; }
        public InteractionAttribute(FighterEventType type)
        {
            this.EventType = type;
        }
    }
}
