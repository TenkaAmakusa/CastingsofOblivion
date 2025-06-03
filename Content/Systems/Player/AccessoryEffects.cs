using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using rail;
using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace COOMod.Content.Systems.Player
{
    public class AccessoryEffects : ModPlayer
    {
        public bool SiphonEquipped;

        public override void ResetEffects()
        {
            SiphonEquipped = false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (SiphonEquipped)
            {
                Player.statMana += damageDone / 10;
            }
        }
    }
}
