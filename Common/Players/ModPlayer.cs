using ExCaL8.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExCaL8.Common.Players;

public class ExCPlayer: ModPlayer
{
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (ExCaL8.ToggleUI.JustPressed)
        {
            ExCUISystem.ToggleWAUI();
        }
    }
}