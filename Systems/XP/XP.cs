using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAC.Systems.XP
{
    /// <summary>
    /// might belong inside XPLevelModule?
    /// </summary>
    public class XP
    {
        public uint Value { get; private set; }

        public XP(uint value = 0)
        {
            Value = value;
        }

        public void Reset()
        {
            Set(0);
        }

        public void Set(uint value)
        {
            Value = value;
        }

        public static XP operator +(XP xp, uint value)
        {
            xp.Value = Utilities.Maths.SafeUIntAdd(xp.Value, value);
            return xp;
        }
        public static XP operator -(XP xp, uint value)
        {
            xp.Value = Utilities.Maths.SafeUIntSubtract(xp.Value, value);
            return xp;
        }
        public static bool operator >(XP xp, uint value) => xp.Value > value;
        public static bool operator <(XP xp, uint value) => xp.Value < value;
        public static bool operator >=(XP xp, uint value) => xp.Value >= value;
        public static bool operator <=(XP xp, uint value) => xp.Value <= value;
    }
}
