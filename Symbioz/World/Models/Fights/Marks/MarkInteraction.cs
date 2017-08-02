using Symbioz.World.Models.Fights.Fighters;
using System.Reflection;

namespace Symbioz.World.Models.Fights.Marks
{
    public class MarkInteraction
    {
        public MarkInteraction(MarkTrigger mark, FighterEventType eventtype, MethodInfo method)
        {
            this.Mark = mark;
            this.EventType = eventtype;
            this.Method = method;
        }
        public MarkTrigger Mark;
        public FighterEventType EventType;
        public MethodInfo Method;
    }
}
