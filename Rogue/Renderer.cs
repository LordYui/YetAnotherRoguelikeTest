using OpenTK;
using Rogue.Components;
using SunshineConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    class Renderer
    {
        private ConsoleWindow gameWindow;

        public Renderer(ConsoleWindow gW)
        {
            gameWindow = gW;
            Input.OnTick += Input_OnTick;
        }

        private void Input_OnTick()
        {
            GameObject[] renderableGo = GameObject.GameObjects.Where(g => g.HasComponent<RenderComp>()).ToArray();

            foreach(GameObject rGo in renderableGo)
            {
                RenderComp rC = rGo.GetComp<RenderComp>();
                Vector2 tC = rGo.GetComp<TransformComp>().Position;

                gameWindow.Write((int)tC.Y, (int)tC.X, rC.Char, rC.Foreground, rC.Background);
            }
        }

        private void ClearScreen()
        {

        }
    }
}
