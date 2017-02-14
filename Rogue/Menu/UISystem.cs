using OpenTK;
using Rogue.Components;

namespace Rogue.Menu
{
    class UISystem
    {
        public GameObject canvasGo;
        public CanvasComp canvas;
        public MenuComp mainMenu;
        public MenuComp subMenu;

        public UISystem()
        {
            Input.OnKeyDown += Input_OnKeyDown;

            canvasGo = new GameObject("Canvas");
            canvas = canvasGo.AddComp<CanvasComp>();
            canvas.ScreenSpacePos = new Vector2(90, 0);
            canvas.Size = new Vector2(30, 40);

            mainMenu = canvasGo.AddComp<MenuComp>();
            mainMenu.Controls.Add(new Label(mainMenu, "Lmao") { Size = new Vector2(4, 1) });

            subMenu = canvasGo.AddComp<MenuComp>();
            subMenu.Controls.Add(new Label(mainMenu, "Topkek") { Size = new Vector2(6, 1) });

            canvas.Show(mainMenu);
        }

        private void Input_OnKeyDown(InputKey e, InputFocusLock lo)
        {
            if (e.Key == OpenTK.Input.Key.Q)
            {
                canvas.Show(subMenu);
            }
            else if (e.Key == OpenTK.Input.Key.E)
            {
                canvas.CloseCurrentMenu();
            }
        }
    }
}
