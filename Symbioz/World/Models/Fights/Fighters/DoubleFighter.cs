using Symbioz.DofusProtocol.Types;
using System;

namespace Symbioz.World.Models.Fights.Fighters
{
    public class DoubleFighter : Fighter
    {
        public Fighter Master { get; set; }

        public DoubleFighter(FightTeam team, Fighter master) : base(team)
        {

        }
        public override FightTeamMemberInformations GetFightMemberInformations()
        {
            throw new NotImplementedException();
        }

        public override Records.Spells.SpellLevelRecord GetSpellLevel(ushort spellid)
        {
            throw new NotImplementedException();
        }

        public override int GetInitiative()
        {
            throw new NotImplementedException();
        }
        public override void StartTurn()
        {
            base.StartTurn();

        }
        public override void RefreshStats()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
