using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EAC
{
	public partial class EAC : Mod
	{
        /// <summary>
        /// Shortcut to "Mod"
        /// </summary>
        public static Mod Mod => ModLoader.GetMod("EAC");

		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Netmode Shortcuts ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		public static bool NETMODE_SERVER { get { return (Main.netMode == NetmodeID.Server); } }
		public static bool NETMODE_CLIENT { get { return (Main.netMode == NetmodeID.MultiplayerClient); } }
		public static bool NETMODE_SINGLEPLAYER { get { return (Main.netMode == NetmodeID.SinglePlayer); } }
		/// <summary>
		/// Client or singleplayer
		/// </summary>
		public static bool NETMODE_PLAYER { get { return (Main.netMode != NetmodeID.Server); } }
		/// <summary>
		/// Server or singleplayer
		/// </summary>
		public static bool NETMODE_EFFECTIVELY_SERVER { get { return (Main.netMode != NetmodeID.MultiplayerClient); } }
	}
}