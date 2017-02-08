using Rogue.GObjects;
using SunshineConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    class MainTick
    {
        public ConsoleWindow GameWindow;
        public Renderer GameRenderer;
        public Input GameInput;

        public PlayerSystem playerSystem;

        public MainTick()
        {
            GameWindow = new ConsoleWindow(40, 80, "Test");
            GameRenderer = new Renderer(GameWindow);
            GameInput = new Input(GameWindow);

            playerSystem = new PlayerSystem();

            Update();
        }

        private void Update()
        {
            while (GameWindow.WindowUpdate()) ;
        }
    }
}
