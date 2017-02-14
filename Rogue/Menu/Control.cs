using OpenTK;
using Rogue.Components;

namespace Rogue.Menu
{
    abstract class Control
    {
        private Vector2 _size;

        public MenuComp ParentMenu { get; protected set; }
        public Vector2 Position { get; set; }
        public Vector2 Size
        {
            get
            {
                return _size;
            }
            set
            {
                Buffer = new char[(int)value.X, (int)value.Y];
                _size = value;

                Refresh();
            }
        }

        public char[,] Buffer { get; private set; }

        public Control(MenuComp parentMenu)
        {
            ParentMenu = parentMenu;
        }

        public abstract void Refresh();

        public virtual void OnKeyDown(InputKey key, InputFocusLock inputLock) { }
    }
}
