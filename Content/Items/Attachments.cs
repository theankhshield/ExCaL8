using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace ExCaL8.Content.Items.Attachments;

public class Scope : ModItem
{
    public byte ScopeType;
    public override string Name => NameArray[ScopeType];
    public override void SetDefaults()
    {
        switch (ScopeType)
        {
            default:
                break;
        }
    }
    #region ScopeStatics
    public static byte AttachmentClass = 0;
    public static string[] NameArray =
    {
        nameof(RedDot)
    };
    public static byte RedDot = 0;
    #endregion
}

public class Magazine : ModItem
{
    public byte MagazineType;
    public override string Name
    {
        get
        {
            switch (MagazineType)
            {
                case 1: return "RedDot";
                default:
                    return "Holographic";
            }
        }
    }
    public override void SetDefaults()
    {
    }
    #region MagazineStatics
    public static byte AttachmentClass = 1;
    #endregion
}

public class Muzzle : ModItem
{
    public byte MuzzleType;
    public override string Name
    {
        get
        {
            switch (MuzzleType)
            {
                case 1: return "RedDot";
                default:
                    return "Holographic";
            }
        }
    }
    public override void SetDefaults()
    {
    }
    #region MuzzleStatics
    public static byte AttachmentClass = 2;
    #endregion
}




public class Grip : ModItem
{
    public byte GripType;
    public override string Name
    {
        get
        {
            switch (GripType)
            {
                case 1: return "RedDot";
                default:
                    return "Holographic";
            }
        }
    }
    public override void SetDefaults()
    {
    }
    #region GripStatics
    public static byte AttachmentClass = 3;
    #endregion
}
public class Stock : ModItem
{

    public byte StockType;
    public override string Name
    {
        get
        {
            switch (StockType)
            {
                case 1: return "RedDot";
                default:
                    return "Holographic";
            }
        }
    }
    public override void SetDefaults()
    {
    }

    #region StockStatics
    public static byte AttachmentClass = 4;
    #endregion
}



public class SideScope : ModItem
{
    public byte ScopeType;
    public override string Name
    {
        get
        {
            switch (ScopeType)
            {
                case 1: return "RedDot";
                default:
                    return "Holographic";
            }
        }
    }
    public override void SetDefaults()
    {
    }
    #region ScopeStatics
    public static byte AttachmentClass = 5;
    #endregion
}
public class Camo : ModItem
{
    public byte CamoType;
    public override string Name
    {
        get
        {
            switch (CamoType)
            {
                case 1: return "RedDot";
                default:
                    return "Holographic";
            }
        }
    }
    public override void SetDefaults()
    {
    }
    #region CamoStatics
    public static byte AttachmentClass = 6;
    #endregion
}
