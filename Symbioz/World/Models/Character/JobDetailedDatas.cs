using Symbioz.DofusProtocol.Types;
using System.Collections.Generic;

namespace Symbioz.World.Models
{
    public class JobsDetailedDatas
    {
        public List<JobDescription> JobsDescriptions = new List<JobDescription>();
        public List<JobExperience> JobsExperiences = new List<JobExperience>();
        public List<JobCrafterDirectorySettings> JobSettings = new List<JobCrafterDirectorySettings>();
    }
}
