using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue.Components;

namespace Rogue.Menu
{
    class MainMenu : IGameMenu
    {
        public override void Open(UIRenderComp ui)
        {
            ui.ResetBuffer();
            ui.ScreenSpacePos = new OpenTK.Vector2(90, 0);
            ui.Size = new OpenTK.Vector2(30, 90);

            ui.Columns = 2;

            ui.AppendLine("a - Test");
            ui.AppendLine("b - More test", 1);
        }
    }
}
