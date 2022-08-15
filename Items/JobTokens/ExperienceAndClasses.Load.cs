using Terraria.ModLoader;

namespace EAC
{
    public partial class EAC : Mod
    {
        public override void Load()
        {
            //create job token items
            Items.JobTokens.JobToken.LoadTokens(this);
        }
    }
}
