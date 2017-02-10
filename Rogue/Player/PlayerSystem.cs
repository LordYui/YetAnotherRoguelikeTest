using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using Rogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Player
{
    class PlayerSystem
    {
        public GameObject PlayerGo = new GameObject();

        public PlayerSystem()
        {
            PlayerGo = new GameObject("player_object");

            transformComp = PlayerGo.AddComp<TransformComp>();
            PlayerGo.AddComp<CameraComp>();
            RenderComp rC = PlayerGo.AddComp<RenderComp>();
            rC.Char = 'X';
            rC.Foreground = Color4.OrangeRed;
            rC.Priority = 1;

            transformComp.Position = new Vector2(45, 15);

            Input.OnKeyDown += Input_OnKeyDown;
        }

        private TransformComp transformComp;
        private void Input_OnKeyDown(InputKey e, ref InputFocusLock l)
        {
            switch (e.Key)
            {
                case Key.W:
                    transformComp.Position += new Vector2(0, -1);
                    break;
                case Key.A:
                    transformComp.Position += new Vector2(-1, 0);
                    break;
                case Key.S:
                    transformComp.Position += new Vector2(0, 1);
                    break;
                case Key.D:
                    transformComp.Position += new Vector2(1, 0);
                    break;
            }
        }
    }
}
