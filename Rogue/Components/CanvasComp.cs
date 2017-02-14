using OpenTK;
using System.Collections.Generic;

namespace Rogue.Components
{
    class CanvasComp : Component
    {
        public Vector2 ScreenSpacePos;

        private Vector2 size = new Vector2(1, 1);
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                Buffer = new char[(int)value.X, (int)value.Y];
            }
        }
        public char[,] Buffer = new char[1, 1];

        public MenuComp CurrentMenu
        {
            get
            {
                if (ShownMenus.Count <= 0) return null;

                return ShownMenus.Peek();
            }
        }
        public Stack<MenuComp> ShownMenus = new Stack<MenuComp>();

        public void CloseCurrentMenu()
        {
            if (ShownMenus.Count > 0)
                ShownMenus.Pop();

            if (ShownMenus.Count > 0)
                ShownMenus.Peek().Refresh();

            if (ShownMenus.Count <= 0)
                ClearBuffer();
        }
        public void Show(MenuComp menu)
        {
            ShownMenus.Push(menu);
            menu.OnRefreshed += Menu_OnRefreshed;
            menu.Refresh();
        }

        private void ClearBuffer()
        {
            Buffer = new char[(int)Size.X, (int)Size.Y];
        }

        private void Menu_OnRefreshed(char[,] buffer)
        {
            for (int y = 0; y < buffer.GetLength(1); y++)
            {
                for (int x = 0; x < buffer.GetLength(0); x++)
                {
                    Buffer[x, y] = buffer[x, y];
                }
            }
        }
    }
}
