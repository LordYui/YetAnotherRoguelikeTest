using Rogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Menu
{
    abstract class IGameMenu
    {
        public delegate void OnClosedHandled();
        public event OnClosedHandled OnClosed;

        public abstract void Open(UIRenderComp ui);
        public void Close()
        {
            OnClosed?.Invoke();
        }

        public virtual void OnKeyDown(InputKey e) { }
    }
}
