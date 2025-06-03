using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace COOMod.Content.Tiles
{
    public class WindsweptTorch : ModTile
    {
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.DisableSmartInteract[Type] = true;
            TileID.Sets.Torch[Type] = true;

            AdjTiles = [TileID.Torches];
            VanillaFallbackOnModDeletion = TileID.Torches;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            
            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Torches, 0));

            AddMapEntry(new Color(200, 200, 200), Language.GetText("ItemName.Torch"));

            AddMapEntry(new Color(200, 200, 200), Language.GetText("ItemName.Torch"));

            flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconEnabled = true;

            int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
            player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];

            if (tile.TileFrameX < 66)
            {
                r = 0.9f;
                g = 0.9f;
                b = 0.9f;
            }
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            // Lowers torch if tile above, taken from ExampleMod
            offsetY = 0;

            if (WorldGen.SolidTile(i, j - 1))
            {
                offsetY = 4;
            }
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            var tile = Main.tile[i, j];

            if (!TileDrawing.IsVisible(tile))
            {
                return;
            }

            int offsetY = 0;

            if (WorldGen.SolidTile(i, j - 1))
            {
                offsetY = 4;
            }

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); 
            Color color = new Color(100, 100, 100, 0);
            int width = 20;
            int height = 20;
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;

            for (int k = 0; k < 7; k++)
            {
                float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + xx, j * 16 - (int)Main.screenPosition.Y + offsetY + yy) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}