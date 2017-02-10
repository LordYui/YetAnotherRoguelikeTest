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
        public delegate void OnClosedHandled(bool clearStack);
        public event OnClosedHandled OnClosed;

        public abstract void Open(UIRenderComp ui);
        public void Close(bool clearStack = true)
        {
            OnClosed?.Invoke(clearStack);
        }

        public virtual void OnKeyDown(InputKey e, InputFocusLock l = null) { }
    }
}
