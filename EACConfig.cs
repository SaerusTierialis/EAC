using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace EAC
{
    public class EACConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.EAC.Config.Server.TODO")] 
        [Label("$Mods.EAC.Config.Server.TODO")] 
        [Tooltip("$Mods.EAC.Config.Server.TODO")]
        [DefaultValue(100)]
        public byte MaxEffectiveLevel;

        [Header("$Mods.EAC.Config.Server.TODO")]
        [Label("$Mods.EAC.Config.Server.TODO")]
        [Tooltip("$Mods.EAC.Config.Server.TODO")]
        [DefaultValue(1f)]
        [Range(0f, 10f)]
        [Increment(.01f)]
        public float DamageStatMultiplier;
    }

    public class EACConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}
