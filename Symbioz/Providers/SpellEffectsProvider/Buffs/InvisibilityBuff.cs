using Symbioz.DofusProtocol.Messages;
using Symbioz.DofusProtocol.Types;
using Symbioz.Enums;

namespace Symbioz.Providers.SpellEffectsProvider.Buffs
{
    public class InvisibilityBuff : Buff
    {
        public InvisibilityBuff(uint uid, short delta, short duration, int sourceid, short sourcespellid, int delay)
            : base(uid, delta, duration, sourceid, sourcespellid, delay)
        {

        }
        public override void SetBuff()
        {
            Fighter.Fight.Send(new GameActionFightDispellableEffectMessage((ushort)EffectsEnum.Eff_Invisibility,
                SourceId, new FightTemporaryBoostEffect((uint)Fighter.BuffIdProvider.Pop(),
                    Fighter.ContextualId, Duration, 1, (ushort)SourceSpellId, (uint)EffectsEnum.Eff_Invisibility, 0, Delta)));

            Fighter.FighterStats.InvisiblityState = GameActionFightInvisibilityStateEnum.INVISIBLE;

            //Fighter.Team.Send(new  GameActionFightInvisibilityMessage((ushort)ActionsEnum.ACTION_CHARACTER_MAKE_INVISIBLE,
            // SourceId,Fighter.ContextualId,(sbyte)Fighter.FighterStats.InvisiblityState));

        }

        public override void RemoveBuff()
        {
            Fighter.FighterStats.InvisiblityState = GameActionFightInvisibilityStateEnum.VISIBLE;
        }
    }
}
