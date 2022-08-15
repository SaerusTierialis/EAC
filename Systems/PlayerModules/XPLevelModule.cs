using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EAC.Systems.PlayerModules
{
    public class XPLevelModule : Module
    {
        public byte TotalLevel { get; private set; } = 25; //TODO
        public bool LevelIsCapped => (TotalLevel >= ModContent.GetInstance<EACConfigServer>().MaxEffectiveLevel);
        public byte TotalLevelCapped => Math.Min(TotalLevel, ModContent.GetInstance<EACConfigServer>().MaxEffectiveLevel);
        public byte EffectiveLevel => (byte)(TotalLevelCapped * Owner.PlayerData.JobModule.MultiJobLevelModifier);

        public XPLevelModule(EACPlayer eacplayer) : base(eacplayer, starts_active: true) { }

        public override void OnSave(TagCompound tag)
        {
            //TODO
        }

        public override void OnLoad(TagCompound tag)
        {
            //TODO
        }
    }
}
