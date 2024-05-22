
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using ExCaL8.Common.UI.WAUI;
using System;
using log4net.Util;
using ExCaL8.Content.Items.Weapons;
namespace ExCaL8.Common.UI;

public class ExCUISystem : ModSystem
{
    public static UserInterface WAttachmentsUI;
    public static WAUIState WeaponAttachments;
    public static void ToggleWAUI(ExCWeapon gun)
    {
        if (WAttachmentsUI.CurrentState == null)
        {
            WAttachmentsUI.SetState(WeaponAttachments);
        }
        else
        {
            WAttachmentsUI.SetState(null);
        }
    }
    public override void Load()
    {
        if (Main.dedServ) { return; }
        WeaponAttachments = new ();
        WeaponAttachments.Activate();
        WAttachmentsUI = new ();
        WAttachmentsUI.SetState(WeaponAttachments);
    }
    public override void UpdateUI(GameTime gameTime)
    {
        if (WAttachmentsUI?.CurrentState != null)
        {
            WAttachmentsUI.Update(gameTime);
        }
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (mouseTextIndex != -1)
        {
            layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "ExampleMod: Coins Per Minute",
                delegate {
                    if (WAttachmentsUI?.CurrentState != null)
                    {
                        WAttachmentsUI.Draw(Main.spriteBatch, new GameTime());
                    }
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }
    }

    public static void SetUIERectPixel(UIElement uIElement, float top, float left, float width, float height)
    {
        uIElement.Top.Pixels = top;
        uIElement.Left.Pixels = left;
        uIElement.Width.Pixels = width;
        uIElement.Height.Pixels = height;
    }
    public static void SetUIPosPixel(UIElement uIElement, float top, float left)
    {
        uIElement.Top.Pixels = top;
        uIElement.Left.Pixels = left;
    }
}
