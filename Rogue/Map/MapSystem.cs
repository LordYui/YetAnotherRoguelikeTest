using OpenTK;
using OpenTK.Graphics;
using Rogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Map
{
    class MapSystem
    {
        public MapSystem()
        {
            LoadMap();
        }

        private Random diceRoll = new Random();
        public GameObject[,] LoadMap()
        {
            GameObject[,] retMap = new GameObject[Renderer.GAME_VIEW_WIDTH, Renderer.GAME_VIEW_HEIGHT];

            for (int x = 0; x < Renderer.GAME_VIEW_WIDTH; x++)
            {
                for (int y = 0; y < Renderer.GAME_VIEW_HEIGHT; y++)
                {
                    GameObject nG = new GameObject();
                    RenderComp rC = nG.AddComp<RenderComp>();
                    rC.Foreground = Color4.ForestGreen;

                    switch (diceRoll.Next(4))
                    {
                        case 0:
                            rC.Char = '.';
                            break;
                        case 1:
                            rC.Char = ';';
                            break;
                        case 2:
                            rC.Char = ',';
                            break;
                        case 3:
                            rC.Char = ':';
                            break;
                    }

                    TransformComp tC = nG.AddComp<TransformComp>();
                    tC.Position = new Vector2(x, y);

                    retMap[x, y] = nG;
                }
            }
            return retMap;
        }
    }
}
