using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader.IO;

namespace EAC.Systems.PlayerModules
{
    public abstract class Module
    {
        public enum MODULE_IDS : byte
        {
            Jobs,
            XPLevelModule,
        }
        protected readonly Dictionary<MODULE_IDS, Module> Modules = new Dictionary<MODULE_IDS, Module>();

        public readonly EACPlayer Owner;
        public bool Active;

        public Module(EACPlayer eacplayer, bool starts_active = false)
        {
            Owner = eacplayer;
            Active = starts_active;
        }

        public bool OwnerIsLocal => (Main.LocalPlayer.whoAmI == Owner.Player.whoAmI);

        public void PreUpdate()
        {
            if (Active)
            {
                OnPreUpdate();
                foreach (var module in Modules.Values)
                {
                    module.PreUpdate();
                }
            }
        }

        public virtual void OnPreUpdate() { }

        public void PostUpdateEquips()
        {
            if (Active)
            {
                OnPostUpdateEquips();
                foreach ( var module in Modules.Values )
                {
                    module.PostUpdateEquips();
                }
            }
        }

        public virtual void OnPostUpdateEquips() { }

        public void Save(TagCompound tag)
        {
            OnSave(tag);
            foreach (var module in Modules.Values)
            {
                module.Save(tag);
            }
        }
        public virtual void OnSave(TagCompound tag) { }

        public void Load(TagCompound tag)
        {
            OnLoad(tag);
            foreach (var module in Modules.Values)
            {
                module.Load(tag);
            }
        }
        public virtual void OnLoad(TagCompound tag) { }

    }
}
