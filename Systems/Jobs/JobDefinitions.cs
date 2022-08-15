using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAC.Utilities;
using EAC.Systems.Stats;
using Terraria.ID;

namespace EAC.Systems.Jobs
{
    public static class JobDefinitions
    {
        //IMPORTANT: each entry MUST have a class with the exact same name
        public enum JOB_ID : byte
        {
            T1_Novice,
            T2_Squire,
            T3_Warrior,
        }

        //lookup
        public static readonly Dictionary<JOB_ID, Job> LOOKUP = new Dictionary<JOB_ID, Job>();

        static JobDefinitions()
        {
            foreach (JOB_ID type in Enum.GetValues(typeof(JOB_ID)))
            {
                LOOKUP[type] = Commons.CreateObjectFromName<Job>(Enum.GetName(typeof(JOB_ID), type), typeof(JobDefinitions));
            }
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Start of Actual Jobs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public class T1_Novice : Job
        {
            public T1_Novice() : base(tier: 1,
                                        stats: new List<Stats.Stat> {
                                            new StatDefinitions.GenericDamagePctInc(0.02f)
                                        },
                                        ingredients: new List<(int itemID, int stack)>
                                        {
                                            (ItemID.DirtBlock, 10)
                                        }
                                        ) { }
        }

        public class T2_Squire : Job
        {
            public T2_Squire() : base(  tier: 2,
                                        jobID_prereq: JOB_ID.T1_Novice,
                                        stats: new List<Stats.Stat> {
                                            new StatDefinitions.GenericDamagePctInc(0.03f)
                                        },
                                        ingredientsGroup: new List<(string name, int stack)>
                                        {
                                            ("IronBar", 10)
                                        }
                                        ) { }
        }

        public class T3_Warrior : Job
        {
            public T3_Warrior() : base( tier: 3,
                                        jobID_prereq: JOB_ID.T2_Squire,
                                        stats: new List<Stats.Stat> {
                                            new StatDefinitions.GenericDamagePctInc(0.05f)
                                        },
                                        ingredientsGroup: new List<(string name, int stack)>
                                        {
                                            ("IronBar", 100)
                                        }
                                        ) { }
        }
    }
}
