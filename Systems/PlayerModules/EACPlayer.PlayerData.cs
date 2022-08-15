using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.IO;

namespace EAC
{
    public partial class EACPlayer
    {
        public Systems.PlayerModules.PlayerData PlayerData { get; private set; }

        public override void Initialize()
        {
            PlayerData = new Systems.PlayerModules.PlayerData(this);
        }

        public override void PreUpdate()
        {
            PlayerData.PreUpdate();
        }

        public override void PostUpdateEquips()
        {
            PlayerData.PostUpdateEquips();
        }

        public override void SaveData(TagCompound tag)
        {
            PlayerData.Save(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            PlayerData.Load(tag);
        }
    }
}
