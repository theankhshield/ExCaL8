using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.UI;

namespace ExCaL8.Common.UI.Elements;

public delegate bool IsItemAllowedDelegate(Item item);
public delegate void OnStoringItemDelegate(Item item);

public class CustomSlot : UIElement
{
    public bool visible = true;
    public Item[] items;
    public int itemindex;
    public int invcontex;
    public IsItemAllowedDelegate IsItemAllowed;
    public OnStoringItemDelegate OnStoringItem;
    public CustomSlot(Item[] items, int itemindex, int invcontex = ItemSlot.Context.InventoryItem, IsItemAllowedDelegate IsItemAllowed = null, OnStoringItemDelegate onStoringItem = null)
    {
        this.items = items;
        this.itemindex = itemindex;
        this.invcontex = invcontex;
        this.IsItemAllowed = IsItemAllowed;
        Width = new(48f, 0);
        Height = new(48f, 0);
        OnStoringItem = onStoringItem;
        
    }
    public CustomSlot(Item item) : this([item], 0, ItemSlot.Context.InventoryItem)
    {

    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        if (visible)
        {

            if (IsMouseHovering && IsItemAllowed?.Invoke(Main.mouseItem) is not false)

            {
                Main.LocalPlayer.mouseInterface = true;
                Item thisitem = items[itemindex];
                Item olditem = thisitem.Clone();
                ItemSlot.OverrideHover(ref thisitem, invcontex);
                ItemSlot.LeftClick(ref thisitem, invcontex);
                ItemSlot.RightClick(ref thisitem, invcontex);
                ItemSlot.MouseHover(ref thisitem, invcontex);
                items[itemindex] = thisitem;
                if (!thisitem.IsNotSameTypePrefixAndStack(olditem))
                    OnStoringItem?.Invoke(thisitem);
            }
            Vector2 position = GetDimensions().Center() + new Vector2(52f, 52f) * -0.5f * Main.inventoryScale;
            ItemSlot.Draw(spriteBatch, items, invcontex, itemindex, position);
        }
    }
}