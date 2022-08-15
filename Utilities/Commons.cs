using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EAC.Utilities
{
    public static class Commons
    {
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Misc ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /// <summary>
        /// Create Object by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="parent_type"></param>
        /// <returns></returns>
        public static T CreateObjectFromName<T>(string name, Type parent_type = null)
        {
            if (parent_type == null)
                return (T)(Assembly.GetExecutingAssembly().CreateInstance(typeof(T).FullName + "+" + name));
            else
            {
                return (T)(Assembly.GetExecutingAssembly().CreateInstance(parent_type.FullName + "+" + name));
            }
        }
    }
}
