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
        public delegate void NewTopMenuHandler(UIRenderComp menu);
        public event NewTopMenuHandler NewTopMenu;

        public MenuSystem()
        {
            openedMenus = new Stack<MenuComp>();

            GameObject testMenu = CreateMenuObject<TestMenu>(Key.Q, "test_menu");

            //    new GameObject("test_menu");
            //testMenu.AddComp<UIRenderComp>();
            //MenuComp mC = testMenu.AddComp<MenuComp>();
            //mC.MenuKey = Key.Q;
            //mC.GameMenu = new TestMenu();

            Input.OnKeyDown += Input_OnKeyDown;
            MenuComp.OnMenuOpened += MenuComp_OnMenuOpened;
            MenuComp.OnMenuClosed += MenuComp_OnMenuClosed;

            
        }

        public void OpenMainMenu()
        {
            GameObject mainMenu = CreateMenuObject<MainMenu>(Key.Unknown, "main_menu");
            mainMenu.GetComp<MenuComp>().OpenMenu(null);
        }

        //private GameObject[] gameMenues;
        //private GameObject openedMenu;
        //private InputFocusLock inputLock;

        private Stack<MenuComp> openedMenus;

        private void Input_OnKeyDown(InputKey e, InputFocusLock lo)
        {
            var gameMenues = GameObject.GetByComponent<MenuComp>();

            GameObject menuObj = gameMenues.Where(go => go.GetComp<MenuComp>().MenuKey == e.Key).FirstOrDefault();
            if (menuObj == null)
                return;
            MenuComp selectedMenu = menuObj.GetComp<MenuComp>();
            if (selectedMenu == null)
                return;

            selectedMenu.OpenMenu(lo);
            //openedMenu = menuObj;
            //openedMenuComp = selectedMenu;
            //openedMenu.GetComp<UIRenderComp>().ResetBuffer();

            //selectedMenu.Opened = true;
            //selectedMenu.GameMenu.Open(menuObj.GetComp<UIRenderComp>());
            //selectedMenu.GameMenu.OnClosed += GameMenu_OnClosed;

            //inputLock.Lock(OnMenuKeyDown);
        }


        private void UpdateCurrentMenu()
        {
            UIRenderComp menuRender = openedMenus.Peek().gameObject.GetComp<UIRenderComp>();
            NewTopMenu?.Invoke(menuRender);
        }

        private void MenuComp_OnMenuOpened(MenuComp mC)
        {
            openedMenus.Push(mC);
            UpdateCurrentMenu();
        }

        private void MenuComp_OnMenuClosed(MenuComp mC, bool clearStack)
        {
            if (openedMenus.Count > 1) // omit main menu ?
                openedMenus.Pop();
            else
                return;
            if (clearStack)
            {
                foreach (MenuComp m in openedMenus)
                    if(m.gameObject.Name != "main_menu")
                        m.CloseMenu(false);
                UpdateCurrentMenu();
            }
            else
                UpdateCurrentMenu();
        }

        //private MenuComp openedMenuComp;
        //private void OnMenuKeyDown(InputKey e, ref InputFocusLock lo)
        //{
        //    openedMenuComp.GameMenu.OnKeyDown(e);
        //}

        public static GameObject CreateMenuObject<T>(Key k, string name = "") where T : IGameMenu
        {
            GameObject retMenu = new GameObject(name);
            retMenu.AddComp<UIRenderComp>();
            MenuComp menCo = retMenu.AddComp<MenuComp>();
            menCo.MenuKey = k;
            menCo.GameMenu = Activator.CreateInstance<T>();
            return retMenu;
        }
    }
}
