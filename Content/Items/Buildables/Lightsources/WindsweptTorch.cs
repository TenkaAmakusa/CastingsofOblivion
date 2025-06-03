using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace COOMod.Content.Items.Buildables.Lightsources
{
    public class WindsweptTorch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;

            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.ShimmerTorch;
            ItemID.Sets.SingleUseInGamepad[Type] = true;
            ItemID.Sets.Torches[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToTorch(ModContent.TileType<Tiles.WindsweptTorch>(), 1, false);
            Item.value = 50;
        }

        public override void HoldItem(Player player)
        {
            if (player.wet)
            {
                return;
            }

            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 1f, 1f, 1f);
        }

        public override void PostUpdate()
        {
            if (!Item.wet)
            {
                Lighting.AddLight(Item.Center, 1f, 1f, 1f);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Torch)
                .AddIngredient(ItemID.DirtBlock, 5)
                .SortAfterFirstRecipesOf(ItemID.Torch)
                .Register();
        }
    }
}
