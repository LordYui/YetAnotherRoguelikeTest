using OpenTK.Input;
using Rogue.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Components
{
    class MenuComp : Component
    {
        public delegate void OnMenuOpenedHandler(MenuComp mC);
        public static event OnMenuOpenedHandler OnMenuOpened;

        public delegate void OnMenuClosedHandler(MenuComp mC, bool clearStack = true);
        public static event OnMenuClosedHandler OnMenuClosed;

        public bool Opened { get; private set; }
        public Key MenuKey;
        public IGameMenu GameMenu;

        private InputFocusLock inputFocus;

        public void OpenMenu(InputFocusLock inFoc)
        {
            inputFocus = inFoc;
            GameMenu.OnClosed += GameMenu_OnClosed;
            GameMenu?.Open(gameObject.GetComp<UIRenderComp>());
            OnMenuOpened?.Invoke(this);

            Opened = true;
            inputFocus?.Lock(OnKeyDown);
        }

        private void GameMenu_OnClosed(bool clearStack)
        {
            CloseMenu(clearStack);
        }

        private void OnKeyDown(InputKey e, InputFocusLock l)
        {
            GameMenu.OnKeyDown(e, l);
        }

        public void CloseMenu(bool clear = true)
        {
            Opened = false;
            inputFocus?.Release();
            OnMenuClosed?.Invoke(this, clear);
        }
    }
}
