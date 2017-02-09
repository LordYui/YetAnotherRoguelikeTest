using OpenTK;
using OpenTK.Input;
using Rogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Menu
{
    class MenuSystem
    {
        private UIRenderComp uiCmp;

        public MenuSystem()
        {
            uiCmp = new GameObject("main_menu_object").AddComp<UIRenderComp>();

            uiCmp.ScreenSpacePos = new Vector2(90, 0);
            uiCmp.Size = new Vector2(30, 40);

            uiCmp.Columns = 1;

            uiCmp.AppendLine("a - test  ");
            uiCmp.AppendLine("b - test 2");
            uiCmp.AddLine("");
            uiCmp.AppendLine("c - test  ");
            uiCmp.AppendLine("d - test 2");
        }
    }
}
