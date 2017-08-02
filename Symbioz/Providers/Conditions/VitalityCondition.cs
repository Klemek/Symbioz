using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("cv")]
    public class VitalityCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.PermanentVitality);
        }
    }
    [Condition("CV")]
    public class TotalVitalityCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.Vitality);
        }
    }
}
