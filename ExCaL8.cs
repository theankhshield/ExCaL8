using Microsoft.Xna.Framework.Input;
using System;
using Terraria;
using Terraria.ModLoader;

namespace ExCaL8
{
	public class ExCaL8 : Mod
	{
        public static ModKeybind ToggleUI;
        public override void Load()
        {
            ToggleUI = KeybindLoader.RegisterKeybind(this, "BuffMyFriend", Keys.PageDown);
            
        }
    }
}