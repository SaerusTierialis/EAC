using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAC.Systems.Jobs;

namespace EAC.Systems.PlayerModules
{
    public class JobModule : Module
    {
        public byte JobCount { get; private set; } = 0;
        public bool MultiJob => (JobCount > 1);
        public float MultiJobLevelModifier => MultiJob ? (1f / JobCount) : 1f;

        private List<Job> Jobs = new List<Job>();

        public JobModule(EACPlayer eacplayer) : base(eacplayer, starts_active: true) { }

        public override void OnPreUpdate()
        {
            //clear job list, tokens add jobs on each cycle
            Jobs.Clear();
        }

        public override void OnPostUpdateEquips()
        {
            //count jobs for multi-class penalty
            JobCount = (byte)Jobs.Count;

            //apply job bonuses
            foreach (var job in Jobs)
            {
                job.Apply(Owner);
            }
        }

        public void TryAddJob(JobDefinitions.JOB_ID jobID)
        {
            Jobs.Job job = JobDefinitions.LOOKUP[jobID];
            if (job.CanApply(Owner))
            {
                Jobs.Add(job);
            }
        }
    }
}
