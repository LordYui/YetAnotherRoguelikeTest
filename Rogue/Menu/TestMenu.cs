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

            ui.AddLine("Test Menu");
        }

        public override void OnKeyDown(InputKey e)
        {
            Console.WriteLine($"Hit key in menu: {e.Key}");
            if (e.Key == OpenTK.Input.Key.Q)
                Close();
        }
    }
}
