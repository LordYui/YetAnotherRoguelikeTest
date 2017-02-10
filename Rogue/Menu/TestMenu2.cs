using Rogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Menu
{
    class TestMenu2 : IGameMenu
    {
        public override void Open(UIRenderComp ui)
        {
            ui.ResetBuffer();
            ui.ScreenSpacePos = new OpenTK.Vector2(90, 0);
            ui.Size = new OpenTK.Vector2(30, 90);

            ui.Columns = 2;

            ui.AppendLine("c - Leafy");
            ui.AppendLine("d - Idubbbz", 1);
        }

        public override void OnKeyDown(InputKey e, InputFocusLock l)
        {
            if (e.Key == OpenTK.Input.Key.E)
                Close();
        }
    }
}
