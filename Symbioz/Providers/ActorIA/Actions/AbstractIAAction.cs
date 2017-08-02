using Symbioz.World.Models.Fights.Fighters;

namespace Symbioz.Providers.ActorIA
{
    public abstract class AbstractIAAction
    {
        public abstract void Execute(MonsterFighter fighter);
    }
}
