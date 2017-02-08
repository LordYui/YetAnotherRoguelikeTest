using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Components
{
    class TransformComp : Component
    {
        public Vector2 Position;

        public override void Start()
        {
            Position = Vector2.Zero;
        }
    }
}
