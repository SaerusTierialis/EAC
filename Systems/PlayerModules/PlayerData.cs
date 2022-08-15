using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAC.Systems.PlayerModules
{
    /// <summary>
    /// This is the main module that contains all others
    /// </summary>
    public class PlayerData : Module
    {
        public JobModule JobModule { get { return (JobModule)Modules[MODULE_IDS.Jobs]; } }
        public XPLevelModule XPLevelModule { get { return (XPLevelModule)Modules[MODULE_IDS.XPLevelModule]; } }

        public PlayerData(EACPlayer eacplayer) : base(eacplayer, starts_active: true)
        {
            //populate sub-modules
            Modules[MODULE_IDS.Jobs] = new JobModule(eacplayer);
            Modules[MODULE_IDS.XPLevelModule] = new XPLevelModule(eacplayer);
        }
    }
}
