using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using SunshineConsole;
using static Rogue.Input;

namespace Rogue
{
    class Input
    {
        #region Events
        public delegate void OnTickHandler();
        public static event OnTickHandler OnTick;

        public delegate void OnKeyDownHandler(InputKey e, InputFocusLock lo);
        public static event OnKeyDownHandler OnKeyDown;

        public delegate void OnFocusKeyDownHandler(InputKey e, InputFocusLock lo);
        #endregion

        private ConsoleWindow gameWindow;
        private InputFocusLock inputLock;

        public Input(ConsoleWindow cW)
        {
            gameWindow = cW;
            gameWindow.KeyDown += GameWindow_KeyDown;
            inputLock = new InputFocusLock();
        }

        private void GameWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            InputKey inK = InputKey.InputKeys.Where(k => k.Key == e.Key && k.Modifier == e.Modifiers).FirstOrDefault();

            if (inK.Key == Key.Unknown)
                return;

            if (inputLock.Locked)
                inputLock.InputHandler?.Invoke(inK, inputLock);
            else
            {
                OnKeyDown?.Invoke(inK, inputLock);
                if (inK.ShouldTick)
                    OnTick?.Invoke();
            }
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

            InputKeys.Add(new InputKey(Key.Q));
            InputKeys.Add(new InputKey(Key.E));

            InputKeys.Add(new InputKey(Key.KeypadPlus, 0, true));
            InputKeys.Add(new InputKey(Key.KeypadMinus, 0, true));
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

    class InputFocusLock
    {
        public bool Locked { get; private set; }
        public OnFocusKeyDownHandler InputHandler;

        public void Lock(OnFocusKeyDownHandler handler)
        {
            if (!Locked)
            {
                Locked = true;
                InputHandler = handler;
            }
        }

        public void Release()
        {
            Locked = false;
            InputHandler = null;
        }
    }
}
