using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using EAC.Systems.Jobs;
using Terraria;
using System;

namespace EAC.Items.JobTokens
{
    public class JobToken : ModItem
    {
        public readonly JobDefinitions.JOB_ID JobID;
        private readonly bool Loadable = true;

        public JobToken()
        {
            Loadable = false;
        }

        public JobToken(JobDefinitions.JOB_ID jobID)
        {
            JobID = jobID;
        }

        public override string Name => JobDefinitions.LOOKUP[JobID].TokenName;

        public override string Texture => "EAC/Items/JobTokens/Textures/" + Name;

        public override bool IsLoadingEnabled(Mod mod) => Loadable;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("{$Mods.EAC.Jobs.General.Token}: " + JobDefinitions.LOOKUP[JobID].Name);
            Tooltip.SetDefault(JobDefinitions.LOOKUP[JobID].Tooltip);
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.value = 0;
            Item.accessory = true;
            switch (JobDefinitions.LOOKUP[JobID].Tier)
            {
                case 1:
                    Item.rare = ItemRarityID.Green;
                    break;

                case 2:
                    Item.rare = ItemRarityID.Orange;
                    break;

                case 3:
                    Item.rare = ItemRarityID.Red;
                    break;

                default:
                    Item.rare = ItemRarityID.White;
                    break;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //TODO
        }

        public override void AddRecipes()
        {
            //start
            Recipe recipe = CreateRecipe();

            //ingredients
            JobDefinitions.LOOKUP[JobID].AddIngredients(recipe);

            //where
            recipe.AddTile(TileID.WorkBenches);

            //done
            recipe.Register();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<EACPlayer>().PlayerData.JobModule.TryAddJob(JobID);
        }
    }
}
