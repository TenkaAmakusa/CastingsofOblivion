using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using COOMod.Content.Systems.Player; 

namespace COOMod.Content.Items.Accessories.ClassSpec.Mage
{
    public class Siphon : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            player.GetDamage(DamageClass.Magic) += 25 / 100f;
            player.statManaMax2 += 100;
            player.manaCost += 50 / 100f;
            player.GetModPlayer<AccessoryEffects>().SiphonEquipped = true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
