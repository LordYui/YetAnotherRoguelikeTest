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
        public MenuSystem()
        {
            GameObject testMenu = new GameObject("test_menu");
            testMenu.AddComp<UIRenderComp>();
            MenuComp mC = testMenu.AddComp<MenuComp>();
            mC.MenuKey = Key.Q;
            mC.GameMenu = new TestMenu();

            Input.OnKeyDown += Input_OnKeyDown;
        }

        private GameObject[] gameMenues;
        private GameObject openedMenu;
        private InputFocusLock inputLock;

        private void Input_OnKeyDown(InputKey e, ref InputFocusLock lo)
        {
            inputLock = lo;
            gameMenues = GameObject.GetByComponent<MenuComp>();

            GameObject menuObj = gameMenues.Where(go => go.GetComp<MenuComp>().MenuKey == e.Key).FirstOrDefault();
            if (menuObj == null)
                return;
            MenuComp selectedMenu = menuObj.GetComp<MenuComp>();
            if (selectedMenu == null)
                return;

            openedMenu = menuObj;
            openedMenuComp = selectedMenu;
            openedMenu.GetComp<UIRenderComp>().ResetBuffer();

            selectedMenu.Opened = true;
            selectedMenu.GameMenu.Open(menuObj.GetComp<UIRenderComp>());
            selectedMenu.GameMenu.OnClosed += GameMenu_OnClosed;

            inputLock.Lock(OnMenuKeyDown);
        }

        private void GameMenu_OnClosed()
        {
            openedMenuComp.Opened = false;
            inputLock.Release();
        }

        private MenuComp openedMenuComp;
        private void OnMenuKeyDown(InputKey e, ref InputFocusLock lo)
        {
            openedMenuComp.GameMenu.OnKeyDown(e);
        }
    }
}
