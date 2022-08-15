using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EAC.Systems.Stats
{
    public abstract class Stat
    {
        public readonly float ValuePerLevel;
        public readonly bool IsPercent;
        public readonly bool IsDamage;

        public Stat(float valuePerLevel, bool isPercent = false, bool isDamage = false)
        {
            ValuePerLevel = valuePerLevel;
            IsPercent = isPercent;
            IsDamage = isDamage;

            if (IsDamage)
            {
                ValuePerLevel = ValuePerLevel * ModContent.GetInstance<EACConfigServer>().DamageStatMultiplier;
            }
        }

        public string GetTooltipLine(byte effective_level)
        {
            //start with + if positive (- included in number if negative)
            string str = (ValuePerLevel > 0) ? "+" : "";

            //add value
            float value = ValuePerLevel * effective_level;
            if (IsPercent)
            {
                str += Math.Round(value * 100) + "%";
            }
            else
            {
                str += Math.Round(value);
            }

            //add label
            str += " " + Language.GetTextValue("Mods.EAC.Stats." + GetType().Name);

            //add value per level
            str += " (";
            if (IsPercent)
            {
                str += Math.Round(ValuePerLevel * 100, 2) + "%";
            }
            else
            {
                str += Math.Round(ValuePerLevel, 2);
            }
            str += " " + Language.GetTextValue("Mods.EAC.Stats.PerLevel") + ")";

            //done
            return str;
        }

        public abstract void Apply(EACPlayer eacplayer, byte effective_level);
    }
}
