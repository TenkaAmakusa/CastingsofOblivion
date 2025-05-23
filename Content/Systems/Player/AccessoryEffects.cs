using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace COOMod.Content.Systems.Player
{
    public class AccessoryEffects : ModPlayer
    {
        public bool SiphonEquipped;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (SiphonEquipped)
            {
                Player.statMana += damageDone / 10;
            }
        }
    }
}
