using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("CP")]
    public class ActionPointsCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.ActionPoints);
        }
    }
}
