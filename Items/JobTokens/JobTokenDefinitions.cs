using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAC.Systems.Jobs;

namespace EAC.Items.JobTokens
{
    public static class JobTokenDefinitions
    {
        public class JobToken_T1_Novice : JobToken { public JobToken_T1_Novice() : base(JobDefinitions.JOB_ID.T1_Novice) { } }
        public class JobToken_T2_Squire : JobToken { public JobToken_T2_Squire() : base(JobDefinitions.JOB_ID.T2_Squire) { } }
        public class JobToken_T3_Warrior : JobToken { public JobToken_T3_Warrior() : base(JobDefinitions.JOB_ID.T3_Warrior) { } }
    }
}
