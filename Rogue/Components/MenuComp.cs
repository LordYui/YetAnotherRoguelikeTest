using OpenTK.Input;
using Rogue.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Components
{
    class MenuComp : Component
    {
        public bool Opened;
        public Key MenuKey;
        public IGameMenu GameMenu;
    }
}
