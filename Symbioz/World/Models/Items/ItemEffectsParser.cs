using Symbioz.DofusProtocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Symbioz.World.Models
{
    public class ItemEffectsParser
    {
        public List<ObjectEffectDice> ObjectEffects { get; set; }
        public ItemEffectsParser(string str)
        {
            ObjectEffects = new List<ObjectEffectDice>();
            if (str != string.Empty)
                Parse(str);
        }
        public string ConvertToString()
        {
            string str = string.Empty;
            foreach (var effect in ObjectEffects)
            {
                str += effect.actionId;
                str += "#";
                str += effect.diceNum;
                str += "#";
                str += effect.diceSide;
                str += "#";
                str += effect.diceConst;
                str += '|';
            }
            return str;
        }
        public void Parse(string str)
        {
            str = str.Substring(0, str.Length - 1);
            foreach (var s in str.Split('|'))
            {
                List<string> splited = s.Split('#').ToList();
                splited.RemoveAll(x => x == string.Empty);
                ObjectEffectDice eff = new ObjectEffectDice();
                if (splited.Count() > 0)
                {
                    try
                    {
                        if ((ushort.Parse(splited[0]) > 249) && (ushort.Parse(splited[0]) < 255)) // Convertir les %PvP en %global
                        {
                            splited[0] = (ushort.Parse(splited[0]) - 40).ToString();
                        }
                        if ((ushort.Parse(splited[0]) > 259) && (ushort.Parse(splited[0]) < 265)) // Convertir les PvP (fixe) en global (fixe)
                        {
                            splited[0] = (ushort.Parse(splited[0]) - 20).ToString();
                        }
                        if (splited[2] == "0")
                        {
                            eff.actionId = ushort.Parse(splited[0]);
                            eff.diceNum = ushort.Parse(splited[1]);
                            eff.diceSide = ushort.Parse(splited[2]);
                            eff.diceConst = ushort.Parse(splited[3]);
                        }
                        else
                        {
                            if (int.Parse(splited[2]) < 0)
                            {
                                eff.actionId = ushort.Parse(splited[0]);
                                eff.diceNum = ushort.Parse(splited[1]);
                                eff.diceSide = ushort.Parse(splited[1]);
                                eff.diceConst = ushort.Parse(splited[3]);
                            }
                            else
                            {
                                eff.actionId = ushort.Parse(splited[0]);
                                eff.diceNum = ushort.Parse(splited[2]);
                                eff.diceSide = ushort.Parse(splited[2]);
                                eff.diceConst = ushort.Parse(splited[3]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Error("[ItemParsing] " + e.Message);
                    }
                }
                ObjectEffects.Add(eff);
            }
        }
    }
}
