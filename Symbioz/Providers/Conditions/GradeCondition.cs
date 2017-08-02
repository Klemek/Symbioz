using Symbioz.Network.Clients;

namespace Symbioz.Providers.Conditions
{
    [Condition("PP")]
    public class GradeCondition : Condition
    {
        public override bool Eval(WorldClient client)
        {
            return Condition.BasicEval(ConditionValue, ComparaisonSymbol, client.Character.Record.AlignmentGrade);
        }
    }
}
