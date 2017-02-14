using Rogue.Menu;
using System.Collections.Generic;
namespace Rogue.Components
{
    class MenuComp : Component
    {
        public delegate void OnRefreshedHandler(char[,] buffer);
        public event OnRefreshedHandler OnRefreshed;

        public CanvasComp Canvas { get; private set; }
        public List<Control> Controls { get; private set; }
        public char[,] Buffer { get; private set; }

        public override void Start()
        {
            Controls = new List<Control>();
            Canvas = gameObject.GetComp<CanvasComp>();
            Buffer = new char[Canvas.Buffer.GetLength(0), Canvas.Buffer.GetLength(1)];
        }

        public void Refresh()
        {
            foreach (Control control in Controls)
            {
                control.Refresh();

                for (int y = 0; y < control.Buffer.GetLength(1); y++)
                {
                    for (int x = 0; x < control.Buffer.GetLength(0); x++)
                    {
                        Buffer[x + (int)control.Position.X, y + (int)control.Position.Y] = control.Buffer[x, y];
                    }
                }
            }

            OnRefreshed?.Invoke(Buffer);
        }
    }
}
