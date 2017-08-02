using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("PZ")]
    class SubscribedCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return true;
        }
    }
}
