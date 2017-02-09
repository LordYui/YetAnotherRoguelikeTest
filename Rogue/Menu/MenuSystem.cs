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
            Input.OnKeyDown += Input_OnKeyDown;

            uiCmp = new GameObject("main_menu_object").AddComp<UIRenderComp>();

            uiCmp.ScreenSpacePos = new Vector2(90, 0);
            uiCmp.Size = new Vector2(30, 40);

            uiCmp.Columns = 4;
        }

        private void UpdateCols()
        {
            uiCmp.ResetBuffer();
            for (int c = 0; c < uiCmp.Columns; c++)
            {
                uiCmp.AppendLine($"col{c}", c);
            }
        }

        private void Input_OnKeyDown(InputKey e)
        {
            switch (e.Key)
            {
                case Key.KeypadPlus:
                    uiCmp.Columns++;
                    UpdateCols();
                    break;
                case Key.KeypadSubtract:
                    uiCmp.Columns--;
                    UpdateCols();
                    break;
            }
        }
    }
}
