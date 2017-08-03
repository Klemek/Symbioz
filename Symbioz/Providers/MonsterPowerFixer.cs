using Symbioz.Core.Startup;
using Symbioz.World.Records.Monsters;

namespace Symbioz.Providers
{
    /// <summary>
    /// To see
    /// </summary>
    class MonsterPowerFixer
    {
        public const int MAX_POWER = 1500;

        [StartupInvoke("Monsters Power Fix", StartupInvokeType.Internal)]
        public static void FixMonsters()
        {
            foreach (var monster in MonsterGradeRecord.MonstersGrades)
            {
                monster.Power = (short)(monster.Level * 2 + 300);
                if (monster.Power > MAX_POWER)
                    monster.Power = MAX_POWER;
            }
        }
    }
}
