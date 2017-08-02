using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [ConditionAttribute("cs")]
    public class StrengthCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.PermanentStrenght);
        }
    }
    [ConditionAttribute("CS")]
    public class TotalStrengthCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.StatsRecord.Strength);
        }
    }
}
