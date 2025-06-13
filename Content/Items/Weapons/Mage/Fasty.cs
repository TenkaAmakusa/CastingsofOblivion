using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using COOMod.Content.Projectiles;

namespace COOMod.Content.Items.Weapons.Mage
{
    public class Fasty : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.DefaultToStaff(ModContent.ProjectileType<Homer>(), 24, 10, 5);
            Item.damage = 12;
            Item.DamageType = DamageClass.Magic;
            Item.useTime = 4;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(silver: 1);
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;

            // Item.shoot = ModContent.ProjectileType<Homer>();
        }
    }

}
