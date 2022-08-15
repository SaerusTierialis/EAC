using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace EAC
{
    public partial class EACPlayer : ModPlayer
    {
        /// <summary>
        /// Shortcut to local player's EACPlayer
        /// </summary>
        public static EACPlayer Local => Main.LocalPlayer.GetModPlayer<EACPlayer>();

        //start with a novice token
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[]
            {
                new Item(Mod.Find<ModItem>(Systems.Jobs.JobDefinitions.LOOKUP[Systems.Jobs.JobDefinitions.JOB_ID.T1_Novice].TokenName).Type, stack: 1)
            };
        }
    }
}
