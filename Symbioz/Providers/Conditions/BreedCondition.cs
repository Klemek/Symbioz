using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("PG")]
    public class BreedCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            if (client.Character.Record.Breed == sbyte.Parse(ConditionValue))
                return true;
            else
                return false;
        }
    }
}
