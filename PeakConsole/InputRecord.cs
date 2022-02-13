using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PeakConsole
{

    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        public short X;
        public short Y;

        public Coord(short X, short Y)
        {
            this.X = X;
            this.Y = Y;
        }
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct InputRecord
    {
        [FieldOffset(0)] public ushort eventType;
        [FieldOffset(2)] public KeyEventRecord KeyEvent;
        [FieldOffset(2)] public MouseEventRecord MouseEvent;
        [FieldOffset(2)] public WindowBufferSizeEventRecord WindowBufferSizeEvent;
        [FieldOffset(2)] public MenuEventRecord MenuEvent;
        [FieldOffset(2)] public FocusEventRecord FocusEvent;

    }

    [StructLayout(LayoutKind.Explicit)]
    public struct KeyEventRecord
    {
        [FieldOffset(0)] public bool bKeyDown;
        [FieldOffset(1)] public ushort wRepeatCount;
        [FieldOffset(3)] public ushort wVirtualKeyCode;
        [FieldOffset(5)] public ushort wVirtualScanCode;
        [FieldOffset(7)] public ushort UnicodeChar;
        [FieldOffset(7)] public byte AsciiChar;
        [FieldOffset(11)] public uint dwControlKeyState;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseEventRecord
    {
        Coord dwMousePosition;
        uint dwButtonState;
        uint dwControlKeyState;
        uint dwEventFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WindowBufferSizeEventRecord
    {
        Coord dwSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MenuEventRecord
    {
        uint dwCommandId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FocusEventRecord
    {
        public bool bSetFocus;
    }
}
