using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue.Components
{
    class UIRenderComp : Component
    {
        public Vector2 ScreenSpacePos;

        private Vector2 size;
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                Buffer = new char[(int)value.X, (int)value.Y];
            }
        }
        public char[,] Buffer;

        private int columns;
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
                columnPadding = (int)Size.X / columns;
            }
        }

        private int columnPadding;
        private int currentLine = 0;
        private int currentCol = 0;

        public void AddLine(string line, int column = 0)
        {
            foreach (char nC in line)
            {
                Buffer[currentCol + (column * columnPadding), currentLine] = nC;
                ++currentCol;
            }
            ++currentLine;
            currentCol = 0;
        }

        public void AppendLine(string line, int column = 0)
        {
            foreach (char nC in line)
            {
                int col = currentCol + (column * columnPadding);
                if (col >= size.X || currentLine >= size.Y)
                    continue;
                Buffer[col, currentLine] = nC;
                ++currentCol;
            }
        }

        public void ResetBuffer()
        {
            currentCol = 0;
            currentCol = 0;
            Buffer = new char[(int)size.X, (int)size.Y];
        }
    }
}
