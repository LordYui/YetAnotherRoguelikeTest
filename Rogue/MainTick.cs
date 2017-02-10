using Rogue.Player;
using Rogue.Menu;
using SunshineConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue.Map;

namespace Rogue
{
    class MainTick
    {
        public ConsoleWindow GameWindow;
        public Renderer GameRenderer;
        public Input GameInput;

        public MenuSystem menuSystem;
        public PlayerSystem playerSystem;
        public MapSystem mapSystem;

        public MainTick()
        {
            GameWindow = new ConsoleWindow(40, 120, "Test");
            GameRenderer = new Renderer(GameWindow);
            GameInput = new Input(GameWindow);

            playerSystem = new PlayerSystem();
            menuSystem = new MenuSystem();
            mapSystem = new MapSystem();

            GameRenderer.ForceTick();
            GameRenderer.SetMenuSystem(menuSystem);

            Update();
        }

        private void Update()
        {
            while (GameWindow.WindowUpdate() && GameRenderer.RenderUi()) ;
        }
    }
}
