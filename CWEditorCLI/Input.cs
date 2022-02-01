
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class Input
    {
        static List<KeyCode> keys = new List<KeyCode>();

        static Dictionary<KeyCode, bool> pressedLast;
        static Dictionary<KeyCode, bool> pressed;
        static Input()
        {
            Array array = Enum.GetValues(typeof(KeyCode));
            pressedLast = new Dictionary<KeyCode, bool>(array.Length);
            pressed = new Dictionary<KeyCode, bool>(array.Length);

            foreach (var item in array)
            {
                pressedLast.Add((KeyCode)item, false);
                pressed.Add((KeyCode)item, false);
                keys.Add((KeyCode)item);
            }
        }

        public static bool GetKey(KeyCode key)
        {
            return pressed[key];
        }

        public static bool GetKeyDown(KeyCode key)
        {
            return pressed[key] && pressedLast[key] == false;
        }

        public static void Update()
        {
            var tmp = pressedLast;
            pressedLast = pressed;
            pressed = tmp;
            Clear();

            foreach (var key in keys)
            {
                pressed[key] = NativeKeyboard.GetKey(key);
            }

            System.Threading.Thread.Sleep(16);
        }

        static void Clear()
        {
            foreach (var item in keys)
            {
                pressed[item] = false;
            }
        }

    }
}
