using Symbioz.Enums;
using Symbioz.DofusProtocol.Messages;
using Symbioz.Providers.SpellEffectsProvider.Buffs;
using Symbioz.World.Models.Fights.Fighters;
using Symbioz.World.Records.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbioz.Providers.SpellEffectsProvider.Effects
{
    class ApMpEffects
    {
        #region Action Points Effects
        [EffectHandler(EffectsEnum.Eff_LosingAP)]
        public static void LosingAp(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castcellid)
        {
            RemoveAP(fighter, level, effect, affecteds, castcellid);
        }
        [EffectHandler(EffectsEnum.Eff_RemoveAP)]
        public static void RemoveAP(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castcellid)
        {

            foreach (var affected in affecteds)
            {
                // TODO ALGO
                int ap = affected.FighterStats.Stats.ActionPoints;
                int loss = 0;
                ushort dodge = 0;

                for (int i = 0; i < effect.BaseEffect.DiceNum; i++)
                {
                    if (affected.FighterStats.Stats.DodgePA == 0 && ap > 0)
                    {
                        loss++;
                        ap--;
                    }
                    else if (ap > 0)
                    {
                        Random rnd = new Random();
                        int rand = rnd.Next(1, 100);
                        int percentage = (int)(50 * (fighter.FighterStats.Stats.APAttack / affected.FighterStats.Stats.DodgePA) * (ap / affected.FighterStats.Stats.ActionPoints));
                        if (rand < percentage)
                        {
                            loss++;
                            ap--;
                        }
                        else
                        {
                            dodge++;
                        }
                    }
                }

                if (dodge > 0)
                {
                    fighter.Fight.Send(new GameActionFightDodgePointLossMessage((ushort)ActionsEnum.ACTION_FIGHT_SPELL_DODGED_PA, fighter.ContextualId, affected.ContextualId, dodge));
                }

                var buff = new APBuff((uint)affected.BuffIdProvider.Pop(), (short)loss, effect.BaseEffect.Duration, fighter.ContextualId, (short)level.SpellId, effect.BaseEffect.EffectType, effect.BaseEffect.Delay);
                affected.AddBuff(buff);
            }
        }
        [EffectHandler(EffectsEnum.Eff_SubAP)]
        public static void SubAP(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castcellid)
        {
            foreach (var affected in affecteds)
            {
                var buff = new APBuff((uint)affected.BuffIdProvider.Pop(), effect.BaseEffect.DiceNum, effect.BaseEffect.Duration, fighter.ContextualId, (short)level.SpellId, effect.BaseEffect.EffectType, effect.BaseEffect.Delay);
                affected.AddBuff(buff);

            }
        }
        [EffectHandler(EffectsEnum.Eff_AddAP_111)]
        public static void AddAp(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castcellid)
        {
            foreach (var affected in affecteds)
            {
                var buff = new APBuff((uint)affected.BuffIdProvider.Pop(), effect.BaseEffect.DiceNum, effect.BaseEffect.Duration, fighter.ContextualId, (short)level.SpellId, effect.BaseEffect.EffectType, effect.BaseEffect.Delay);
                affected.AddBuff(buff);

            }
        }
        #endregion

        #region Movement Points Effects
        [EffectHandler(EffectsEnum.Eff_AddMP_128)]
        public static void AddMp(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castcellid)
        {
            foreach (var target in affecteds)
            {
                var buff = new MPBuff((uint)target.BuffIdProvider.Pop(), effect.BaseEffect.DiceNum, effect.BaseEffect.Duration, fighter.ContextualId, (short)level.SpellId, effect.BaseEffect.EffectType, effect.BaseEffect.Delay);
                target.AddBuff(buff);
            }
        }
        [EffectHandler(EffectsEnum.Eff_LosingMP)]
        public static void LosingMP(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castspellid)
        {
            LostMp(fighter, level, effect, affecteds, castspellid);
        }
        [EffectHandler(EffectsEnum.Eff_SubMP)]
        public static void SubMp(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castspellid)
        {
            foreach (var target in affecteds)
            {
                MPBuff buff = new MPBuff((uint)target.BuffIdProvider.Pop(), effect.BaseEffect.DiceNum, effect.BaseEffect.Duration, fighter.ContextualId, (short)level.SpellId, effect.BaseEffect.EffectType, effect.BaseEffect.Delay);
                target.AddBuff(buff);
            }
        }
        [EffectHandler(EffectsEnum.Eff_LostMP)]
        public static void LostMp(Fighter fighter, SpellLevelRecord level, ExtendedSpellEffect effect, List<Fighter> affecteds, short castcellid)
        {
            foreach (var affected in affecteds)
            {
                // TODO, ALGO
                int mp = affected.FighterStats.Stats.MovementPoints;
                int loss = 0;
                ushort dodge = 0;

                for (int i = 0; i < effect.BaseEffect.DiceNum; i++)
                {
                    if (affected.FighterStats.Stats.DodgePM == 0 && mp > 0)
                    {
                        loss++;
                        mp--;
                    }
                    else if (mp > 0)
                    {
                        Random rnd = new Random();
                        int rand = rnd.Next(1, 100);
                        int percentage = (int)(50 * (fighter.FighterStats.Stats.MPAttack / affected.FighterStats.Stats.DodgePM) * (mp / affected.FighterStats.Stats.MovementPoints));
                        if (rand < percentage)
                        {
                            loss++;
                            mp--;
                        }
                        else
                        {
                            dodge++;
                        }

                    }
                }

                if (dodge > 0)
                {
                    fighter.Fight.Send(new GameActionFightDodgePointLossMessage((ushort)ActionsEnum.ACTION_FIGHT_SPELL_DODGED_PM, fighter.ContextualId, affected.ContextualId, dodge));
                }

                var buff = new MPBuff((uint)affected.BuffIdProvider.Pop(), (short)loss, effect.BaseEffect.Duration, fighter.ContextualId, (short)level.SpellId, effect.BaseEffect.EffectType, effect.BaseEffect.Delay);
                affected.AddBuff(buff);
            }
        }
        #endregion
    }
}
