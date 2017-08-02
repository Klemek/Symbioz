using Symbioz.ORM;
using System.Collections.Generic;
using System.Linq;

namespace Symbioz.World.Records
{
    [Table("Experiences")]
    class ExperienceRecord : ITable
    {
        public static List<ExperienceRecord> Experiences = new List<ExperienceRecord>();


        public uint Level;
        public ulong Experience;
        public int Honor;
        public ulong Guild;

        public static int Entries
        {
            get
            {
                return Experiences.Count();
            }
        }

        public ExperienceRecord(uint level, ulong exp, int honor, ulong guild)
        {
            this.Level = level;
            this.Experience = exp;
            this.Honor = (int)honor;
            this.Guild = guild;
        }
        public static ulong GetExperienceForLevel(uint level)
        {
            if (level > Entries || level > GetLastCharacterEntrie())
                return 0;
            return Experiences.Find(x => x.Level == level).Experience;
        }
        public static ushort GetHonorForGrade(sbyte grade)
        {

            if (grade > 10 || grade == 0)
                return 0;
            return (ushort)Experiences.Find(x => x.Level == grade).Honor;
        }
        public static ulong GetExperienceForGuild(ushort level)
        {
            if (level > Entries || level > GetLastGuildEntrie())
                return 0;
            return Experiences.Find(x => x.Level == level).Guild;
        }

        public static uint GetLastCharacterEntrie()
        {
            uint Result = (uint)Entries;
            foreach (ExperienceRecord rec in Experiences)
            {
                if (rec.Experience == 0 && rec.Level > 1)
                {
                    Result = rec.Level;
                    return Result;
                }
            }
            return Result;
        }

        public static uint GetLastGuildEntrie()
        {
            uint Result = (uint)Entries;
            foreach (ExperienceRecord rec in Experiences)
            {
                if (rec.Guild == 0 && rec.Level > 1)
                {
                    Result = rec.Level;
                    return Result;
                }
            }
            return Result;
        }
    }
}
