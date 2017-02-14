using Rogue.Components;

namespace Rogue.Menu
{
    class Label : Control
    {
        public string Text { get; set; }

        public Label(MenuComp parentMenu, string text) : base(parentMenu)
        {
            ParentMenu = parentMenu;
            Text = text;
        }

        public override void Refresh()
        {
            for (int x = 0; x < Text.Length; x++)
            {
                Buffer[x, 0] = Text[x];
            }
        }
    }
}
