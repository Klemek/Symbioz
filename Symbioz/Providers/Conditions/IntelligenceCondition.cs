using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("ci")]
    public class IntelligenceCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.PermanentIntelligence);
        }
    }
    [Condition("CI")]
    public class TotalIntelligenceCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.Intelligence);
        }
    }
}
