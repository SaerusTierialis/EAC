using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace EAC.Systems.Jobs
{
    public abstract class Job
    {
        public static readonly byte[] TIER_LEVEL_REQ = new byte[] { 0, 0, 10, 50 };

        public readonly JobDefinitions.JOB_ID JobID;
        public readonly JobDefinitions.JOB_ID? JobID_Prereq;
        public readonly string Name, Tooltip, TokenName;
        public readonly byte Tier;
        public readonly List<Stats.Stat> Stats;
        private readonly List<(int itemID, int stack)> Ingredients = new List<(int itemID, int stack)>();
        private readonly List<(string name, int stack)> IngredientsGroup = new List<(string name, int stack)>();

        public Job(byte tier, List<Stats.Stat> stats, List<(int itemID, int stack)> ingredients = null, List<(string name, int stack)> ingredientsGroup = null, JobDefinitions.JOB_ID? jobID_prereq = null)
        {
            JobID = Enum.Parse<JobDefinitions.JOB_ID>(GetType().Name);
            JobID_Prereq = jobID_prereq;
            Name = "{$Mods.EAC.Jobs." + Enum.GetName(JobID) + ".Name}";
            Tooltip = "{$Mods.EAC.Jobs." + Enum.GetName(JobID) + ".Tooltip}";
            Tier = tier;
            Stats = stats;
            TokenName = "JobToken_" + Enum.GetName(JobID);
            if (ingredients is not null) Ingredients = ingredients;
            if (ingredientsGroup is not null) IngredientsGroup = ingredientsGroup;
        }

        public bool CanApply(EACPlayer eacplayer) => eacplayer.PlayerData.XPLevelModule.TotalLevel >= TIER_LEVEL_REQ[JobDefinitions.LOOKUP[JobID].Tier];

        /// <summary>
        /// Should be called on every cycle during PostUpdateEquips
        /// </summary>
        /// <param name="eacplayer"></param>
        public void Apply(EACPlayer eacplayer)
        {
            if (CanApply(eacplayer))
            {
                //level to use
                byte effective_level = eacplayer.PlayerData.XPLevelModule.EffectiveLevel;

                //update level-scaling bonuses
                ApplyStats(eacplayer, effective_level);
            }
        }

        private void ApplyStats(EACPlayer eacplayer, byte effective_level)
        {
            foreach (Stats.Stat stat in Stats)
            {
                stat.Apply(eacplayer, effective_level);
            }
        }

        public void AddIngredients(Recipe recipe)
        {
            //level requirement
            byte level_req = TIER_LEVEL_REQ[Tier];
            if (level_req > 0)
            {
                recipe.AddCondition(NetworkText.FromKey("Mods.EAC.RecipeCondition.Level", level_req), r => EACPlayer.Local.PlayerData.XPLevelModule.TotalLevel >= level_req);
            }

            //prior token
            if (JobID_Prereq is not null)
            {
                recipe.AddIngredient(EAC.Mod, "JobToken_" + Enum.GetName((JobDefinitions.JOB_ID)JobID_Prereq), 1);
            }

            //todo - add orbs to Ingredients (or increase the stack count)

            //groups
            foreach ((string name, int stack) ingredient in IngredientsGroup)
            {
                recipe.AddRecipeGroup(ingredient.name, ingredient.stack);
            }

            //individual
            foreach ((int itemID, int stack) ingredient in Ingredients)
            {
                recipe.AddIngredient(ingredient.itemID, ingredient.stack);
            }
        }

    }
}
