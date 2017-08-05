using Symbioz.World.Models.Fights.Fighters;
using Symbioz.World.PathProvider;
using System.Linq;

namespace Symbioz.Providers.ActorIA.Actions
{
    //  [IAAction(IAActionsEnum.MOVE_TO_ALLY)]
    class MoveToLowerAllyAction : AbstractIAAction
    {
        public override void Execute(MonsterFighter fighter)
        {
            if (fighter.FighterStats.Stats.MovementPoints <= 0)
            {
                return;
            }
            Logger.Log("IA Bouge vers copaing");
            Fighter closest = fighter.CloserAlly(fighter);
            var path = new Pathfinder(fighter.Fight.Map, fighter.CellId);
            path.PutEntities(fighter.Fight.GetAllFighters());
            var cells = path.FindPath(closest.CellId);
            if (cells.Count > 0)
                cells.Remove(cells.Last());
            cells.Insert(0, fighter.CellId);
            cells = cells.Take(fighter.FighterStats.Stats.MovementPoints + 1).ToList();
            sbyte direction = PathParser.GetDirection(cells.Last());
            fighter.Move(cells, cells.Last(), direction);
        }
    }
}
