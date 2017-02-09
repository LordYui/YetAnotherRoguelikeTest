using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using SunshineConsole;

namespace Rogue
{
    class Input
    {
        #region Events
        public delegate void OnTickHandler();
        public static event OnTickHandler OnTick;

        public delegate void OnKeyDownHandler(InputKey e);
        public static event OnKeyDownHandler OnKeyDown;
        #endregion

        private ConsoleWindow gameWindow;

        public Input(ConsoleWindow cW)
        {
            gameWindow = cW;
            gameWindow.KeyDown += GameWindow_KeyDown;
        }

        private void GameWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            InputKey inK = InputKey.InputKeys.Where(k => k.Key == e.Key && k.Modifier == e.Modifiers).FirstOrDefault();

            if (inK.Key == Key.Unknown)
                return;

            OnKeyDown?.Invoke(inK);
            if (inK.ShouldTick)
                OnTick?.Invoke();
        }
    }

    struct InputKey
    {
        #region Static members
        public static List<InputKey> InputKeys = new List<InputKey>();

        static InputKey()
        {
            InputKeys.Add(new InputKey(Key.W, 0, true));
            InputKeys.Add(new InputKey(Key.A, 0, true));
            InputKeys.Add(new InputKey(Key.S, 0, true));
            InputKeys.Add(new InputKey(Key.D, 0, true));
        }
        #endregion

        public Key Key;
        public KeyModifiers Modifier;
        public bool ShouldTick;

        public InputKey(Key k, KeyModifiers mod = 0, bool sT = false)
        {
            Key = k;
            Modifier = mod;
            ShouldTick = sT;
        }
    }
}
