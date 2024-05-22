using ExCaL8.Common.UI;
using ExCaL8.Common.UI.Elements;
using ExCaL8.Content.Items.Ammos;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using ExCaL8.Content.Items.Attachments;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ExCaL8.Content.Items.Weapons;


public abstract class ExCWeapon : ModItem 
{
    public float recoil = 10;
    public byte[] WAttachments;
    public virtual bool CanAcceptAttachment(byte AttachmentClass, byte AttachmentType = 255)
    {
        return false;
    }
    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.PurificationPowder;
    }

    #region DataManagement
    public override void SaveData(TagCompound tag)
    {
        tag.Set("WAttachments", WAttachments, true);
    }
    public override void LoadData(TagCompound tag)
    {
        WAttachments = tag.Get<byte[]>("WAttachments");
    }
    public override void NetSend(BinaryWriter writer)
    {
        writer.Write((byte)WAttachments.Length);
        for (byte i = 0; i < WAttachments.Length; i++)
        {
            writer.Write(WAttachments[i]);
        }
    }
    public override void NetReceive(BinaryReader reader)
    {
        WAttachments = new byte[reader.ReadByte()];
        for (byte i = 0; i < WAttachments.Length; i++)
        {
            WAttachments[i] = reader.ReadByte();
        }
    }
    #endregion
    #region ToggleUI
    public override void RightClick(Player player)
    {
        ExCUISystem.ToggleWAUI(this);
    }
    #endregion
    
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Recoil();
        return true;
    }
    public virtual void Recoil()
    {
        MouseState mouse = Mouse.GetState();
        Vector2 move = Vector2.UnitY.RotatedByRandom(0.5) * recoil;
        Mouse.SetPosition(mouse.X - (int)move.X, mouse.Y - (int)move.Y);
    }
}

public class M4A1 : ExCWeapon
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
    }
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.width = 62;
        Item.height = 30; 
        Item.scale = 1f;
        Item.rare = ItemRarityID.Green; 
        Item.shootSpeed = 5f;
    }
}

public class AK101 : ExCWeapon
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        Item.width = 62;
        Item.height = 30;
        Item.scale = 1f;
        Item.rare = ItemRarityID.Green;
        Item.shootSpeed = 5f;
    }
    
}