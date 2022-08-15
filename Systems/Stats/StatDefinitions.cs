using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace EAC.Systems.Stats
{
    /// <summary>
    /// Bonuses that scale with level. To be reapplied on every cycle.
    /// 
    /// When adding new stats, be sure to add the name in the Localization hjson.
    /// </summary>
    public static class StatDefinitions
    {
        public class GenericDamagePctInc : Stat
        {
            public GenericDamagePctInc(float valuePerLevel) : base(valuePerLevel, isPercent: true) { }

            public override void Apply(EACPlayer eacplayer, byte level)
            {
                Terraria.Main.NewText("VPL " + ValuePerLevel + " L " + level);
                eacplayer.Player.GetDamage(DamageClass.Generic) += ValuePerLevel * level;
            }
        }

        public class MeleeDamagePctInc : Stat
        {
            public MeleeDamagePctInc(float valuePerLevel) : base(valuePerLevel, isPercent: true) { }

            public override void Apply(EACPlayer eacplayer, byte effective_level)
            {
                eacplayer.Player.GetDamage(DamageClass.Melee) += ValuePerLevel * effective_level;
            }
        }
    }
}
