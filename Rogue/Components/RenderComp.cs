using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Components
{
    class RenderComp : Component
    {
        public char Char;
        public Color4 Foreground;
        public Color4 Background;

        public int Priority;

        public override void Start()
        {
            Char = '?';
            Foreground = Color4.White;
            Background = Color4.Black;
        }
    }
}
