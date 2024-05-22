using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExCaL8.Content.Items.Ammos;

public abstract class RAmmos : ModItem
{
    public int fragmentation;
    public Asset<Texture2D> cartridgetexture;
    public override void Unload()
    {
        cartridgetexture = null;
    }
    public override void SetDefaults()
    {
        Item.scale = 0.5f;
        Item.maxStack = 50;
        Item.width = 15;
        Item.height = 3;
        Item.consumable = true;
        Item.rare = ItemRarityID.Gray;
        Item.ammo = ModContent.ItemType<FMJ_556>();
        Item.shoot = ModContent.ProjectileType<Projectiles.Ammos.Bullet>();

    }
    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {
        cartridgetexture ??= Mod.Assets.Request<Texture2D>("Content/Items/Ammo/Cartridge_556");
        Rectangle SourceRectangle = cartridgetexture.Value.Bounds;
        Main.EntitySpriteDraw(cartridgetexture.Value, Item.Center - Main.screenPosition, SourceRectangle, lightColor, 0, SourceRectangle.Size() / 2, Item.scale, 0);
        return false;
    }


}

public class FMJ_556 : RAmmos
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        Item.ammo = Item.type; // only need for the first ammo of a type (5.56mm RA)
        Item.damage = 70;
        Item.ArmorPenetration = 23;
    }
}

//public class M885_556 : RAmmo
//{

//}

//public class M855A1_556 : RAmmo
//{

//}

//public class M856_556 : RAmmo
//{

//}