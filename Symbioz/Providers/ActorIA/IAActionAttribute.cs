using Symbioz.Providers.ActorIA.Actions;
using System;

namespace Symbioz.Providers.ActorIA
{
    public class IAAction : Attribute
    {
        public IAActionsEnum Action;
        public IAAction(IAActionsEnum action)
        {
            this.Action = action;
        }
    }
}
