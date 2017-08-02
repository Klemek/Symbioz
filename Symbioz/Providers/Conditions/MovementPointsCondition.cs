using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("CM")]
    class MovementPointsCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.MovementPoints);
        }
    }
}
