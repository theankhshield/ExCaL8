using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using ExCaL8.Common.UI.Elements;
using Terraria.UI;
using ExCaL8.Content.Items.Weapons;
using ExCaL8.Content.Items.Attachments;
using Terraria.Cinematics;

namespace ExCaL8.Common.UI.WAUI;



public class WAUIState : UIState
{
    public static ExCWeapon Weapon;
    public static Item[] Attachmentarray;
    public static DraggablePanel WAPanel;
    public static CustomSlot ScopeSlot;
    public static CustomSlot MagSlot;
    public static CustomSlot MuzzleSlot;
    public static CustomSlot GripSlot;
    public static CustomSlot StockSlot;
    public static CustomSlot SideScopeSlot;
    public static CustomSlot CamoSlot;

    public override void OnInitialize()
    {
        WAPanel = new ();
        ExCUISystem.SetUIERectPixel(WAPanel, 400f, 100f, 170f, 70f);
        WAPanel.BackgroundColor = Color.White;
        Append(WAPanel);

        Attachmentarray = new Item[8];
        for (int i = 0; i < 8; i++)
        {
            Attachmentarray[i] = new Item();
        }

        ScopeSlot = new(Attachmentarray, Scope.AttachmentClass);
        MagSlot = new(Attachmentarray, Magazine.AttachmentClass);
        MuzzleSlot = new(Attachmentarray, Muzzle.AttachmentClass);
        GripSlot = new(Attachmentarray, Grip.AttachmentClass);  
        StockSlot = new(Attachmentarray, Stock.AttachmentClass);
        SideScopeSlot = new(Attachmentarray, SideScope.AttachmentClass);
        CamoSlot = new(Attachmentarray, Camo.AttachmentClass);


    }
    public void Next(ExCWeapon Weapon)
    {
        ScopeSlot.visible = Weapon.CanAcceptAttachment(Scope.AttachmentClass);
        MagSlot.visible = Weapon.CanAcceptAttachment(Magazine.AttachmentClass);
        MuzzleSlot.visible = Weapon.CanAcceptAttachment(Muzzle.AttachmentClass);
        GripSlot.visible = Weapon.CanAcceptAttachment (Grip.AttachmentClass);
        StockSlot.visible = Weapon.CanAcceptAttachment(Stock.AttachmentClass);
        SideScopeSlot.visible = Weapon.CanAcceptAttachment(SideScope.AttachmentClass);
        CamoSlot.visible = Weapon.CanAcceptAttachment(Camo.AttachmentClass);


    }

}

public class DraggablePanel : UIPanel
{
    private float offsetX;
    private float offsetY;
    private bool dragging;
    public override void LeftMouseDown(UIMouseEvent evt)
    {
        base.LeftMouseDown(evt);
        
        dragging = true;
        offsetX = Left.Pixels - evt.MousePosition.X;
        offsetY = Top.Pixels - evt.MousePosition.Y;
    }
    public override void LeftMouseUp(UIMouseEvent evt)
    {
        base.LeftMouseUp(evt);
        dragging = false;
        ExCUISystem.SetUIPosPixel(this, Main.mouseY + offsetY, Main.mouseX + offsetX);
        Recalculate();
    }
    public override void Update(GameTime gameTime)
    {
        if (ContainsPoint(Main.MouseScreen))
        {
            Main.LocalPlayer.creativeInterface = true;
        }
        if(dragging)
        {
            ExCUISystem.SetUIPosPixel(this, Main.mouseY + offsetY, Main.mouseX + offsetX);
            Recalculate();
        }
        if(!GetDimensions().ToRectangle().Intersects(Parent.GetDimensions().ToRectangle()))
        {
            ExCUISystem.SetUIPosPixel(this, Utils.Clamp(Top.Pixels, 0, Main.screenHeight - Height.Pixels), Utils.Clamp(Left.Pixels, 0, Main.screenHeight - Width.Pixels));
            Recalculate();
        }
        
    }
}
