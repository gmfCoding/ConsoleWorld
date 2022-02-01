using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    /// <summary>
    /// Codes representing keyboard keys.
    /// </summary>
    /// <remarks>
    /// Key code documentation:
    /// http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
    /// </remarks>
    /// 


    public enum KeyCode : int
    {
        Space = 0x20,
        Left = 0x25,
        Up,
        Right,
        Down,
        A0 = 0x30,
        A1,
        A2,
        A3,
        A4,
        A5,
        A6,
        A7,
        A8,
        A9,
        A = 0x41,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        VK_MULTIPLY = 0x6A,
        VK_ADD,
        VK_SEPARATOR,
        VK_SUBTRAC,
        VK_DECIMAL,
        VK_DIVIDE,
        SQBRACKLEFT = 0xDB,
        Backslash,
        SQBRACKRIGHT,
        LShift = 0xA0,
        RShift,
        LCtrl,
        RCtrl
    }

    /// <summary>
    /// Provides keyboard access.
    /// </summary>
    internal static class NativeKeyboard
    {
        private const int KeyPressed = 0x8000;

        public static bool GetKey(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
