using Rogue.Map;
using Rogue.Menu;
using Rogue.Player;
using SunshineConsole;

namespace Rogue
{
    class MainTick
    {
        public ConsoleWindow GameWindow;
        public Renderer GameRenderer;
        public Input GameInput;

        public PlayerSystem playerSystem;
        public MapSystem mapSystem;
        public UISystem uiSystem;

        public MainTick()
        {
            GameWindow = new ConsoleWindow(40, 120, "Test");
            GameRenderer = new Renderer(GameWindow);
            GameInput = new Input(GameWindow);

            playerSystem = new PlayerSystem();
            mapSystem = new MapSystem();
            uiSystem = new UISystem();

            GameRenderer.ForceTick();

            Update();
        }

        private void Update()
        {
            while (GameWindow.WindowUpdate() && GameRenderer.RenderUi()) ;
        }
    }
}
