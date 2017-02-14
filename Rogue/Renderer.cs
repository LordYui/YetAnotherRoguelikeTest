using OpenTK;
using OpenTK.Graphics;
using Rogue.Components;
using SunshineConsole;
using System;
using System.Linq;

namespace Rogue
{
    class Renderer
    {
        public const int GAME_VIEW_WIDTH = 90;
        public const int GAME_VIEW_HEIGHT = 30;

        private ConsoleWindow gameWindow;
        private GameObject cameraHolder;

        public Renderer(ConsoleWindow gW)
        {
            gameWindow = gW;
            Input.OnTick += Input_OnTick;
        }

        public void ForceTick()
        {
            Input_OnTick();
        }

        Vector2 cameraPos;
        private void Input_OnTick()
        {
            if (cameraHolder == null)
            {
                cameraHolder = GameObject.GameObjects.Where(g => g.HasComponent<CameraComp>()).FirstOrDefault();
                cameraPos = cameraHolder.GetComp<TransformComp>().Position;
            }

            RenderObjects();
            //RenderUi();

        }

        private void RenderObjects()
        {
            GameObject[] renderableGo = GameObject.GameObjects.Where(g => g.HasComponent<RenderComp>()).OrderBy(g => g.GetComp<RenderComp>().Priority).ToArray();

            ClearScreen();

            cameraPos = cameraHolder.GetComp<TransformComp>().Position;

            foreach (GameObject rGo in renderableGo)
            {
                RenderComp rC = rGo.GetComp<RenderComp>();
                Vector2 tC = rGo.GetComp<TransformComp>().Position;

                int xPos = (int)tC.X - (int)cameraPos.X + (GAME_VIEW_WIDTH / 2);
                int yPos = (int)tC.Y - (int)cameraPos.Y + (GAME_VIEW_HEIGHT / 2);

                if (yPos < GAME_VIEW_HEIGHT && xPos < GAME_VIEW_WIDTH && yPos >= 0 && xPos >= 0)
                    gameWindow.Write(yPos, xPos, rC.Char, rC.Foreground, rC.Background);
            }

        }

        public bool RenderUi()
        {
            CanvasComp[] canvases = GameObject.GameObjects.Where(g => g.HasComponent<CanvasComp>()).Select(g => g.GetComp<CanvasComp>()).ToArray();

            foreach (CanvasComp canvas in canvases)
            {
                for (int y = 0; y < canvas.Buffer.GetLength(1); y++)
                {
                    for (int x = 0; x < canvas.Buffer.GetLength(0); x++)
                    {
                        gameWindow.Write(y + (int)canvas.ScreenSpacePos.Y, x + (int)canvas.ScreenSpacePos.X, canvas.Buffer[x, y], Color4.White);
                    }
                }
            }

            return true;
        }

        private void ClearScreen()
        {
            for (int x = 0; x < GAME_VIEW_WIDTH; x++)
            {
                for (int y = 0; y < GAME_VIEW_HEIGHT; y++)
                {
                    gameWindow.Write(y, x, '.', Color4.ForestGreen);
                }
            }
        }

        private void ClearUi()
        {
            for (int x = 90; x < 120; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    gameWindow.Write(y, x, ' ', Color4.Black);
                }
            }
        }

        private Random diceRoller = new Random();
        private Color4[] randomColors = new Color4[] { Color4.White, Color4.Tomato, Color4.Green, Color4.Honeydew };
        private Color4 GetRandomColor()
        {
            return randomColors[diceRoller.Next(randomColors.Length)];
        }
    }
}
