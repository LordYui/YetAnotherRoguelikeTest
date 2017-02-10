﻿using OpenTK.Input;
using Rogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Menu
{
    class TestMenu : IGameMenu
    {
        public override void Open(UIRenderComp ui)
        {
            ui.ResetBuffer();
            ui.ScreenSpacePos = new OpenTK.Vector2(90, 0);
            ui.Size = new OpenTK.Vector2(30, 90);

            ui.Columns = 2;

            ui.AppendLine("a - Bleach");
            ui.AppendLine("b - Memes", 1);
        }

        public override void OnKeyDown(InputKey e, InputFocusLock l)
        {
            Console.WriteLine($"Hit key in menu: {e.Key}");
            if (e.Key == Key.Q)
            {
                l.Release();
                MenuSystem.CreateMenuObject<TestMenu2>(Key.Unknown, "test_sub_menu_1").GetComp<MenuComp>().OpenMenu(l);
            }
                
        }
    }
}
