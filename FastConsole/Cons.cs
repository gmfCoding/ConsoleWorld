using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace FastConsole
{
    public class Cons
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] uint fileAccess,
        [MarshalAs(UnmanagedType.U4)] uint fileShare,
        IntPtr securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        [MarshalAs(UnmanagedType.U4)] int flags,
        IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutputW(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

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
        public struct CharUnion
        {
            [FieldOffset(0)] public ushort UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        public CharInfo[] buf;
        public short width;
        public short height;
        SmallRect rect;
        SafeFileHandle handle;

        public bool autoWrap = true;

        int curX = 0;
        int curY = 0;

        ConsoleColor curFg = ConsoleColor.White;
        ConsoleColor curBg = ConsoleColor.Black;

        public void SetCursor(int x, int y)
        {
            curX = x;
            curY = y;
            ClampCursor();
        }

        void ClampCursor()
        {
            if (curX >= width)
            {
                curX = width;
            }

            if (curY >= height)
            {
                curY = height - 1;
            }
        }


        public void WriteLine(string str, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            Write(str, fg, bg);
            curY++;
            ClampCursor();
        }

        public void Write(string str, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Write(str[i], fg, bg);
            }
        }

        public void Write(char character, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            WriteAt(character, curX, curY, fg, bg);
            curX++;
            if (autoWrap && curX >= width)
            {
                curX = 0;
                curY++;
            }
            ClampCursor();
        }

        public void WriteAt(char character, int x, int y, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            buf[x + y * width].Attributes = (short)((ushort)fg | (ushort)bg << 4);
            buf[x + y * width].Char.UnicodeChar = (ushort)character;
        }

        public void Flush()
        {
            if (!handle.IsInvalid)
            {
                bool b = WriteConsoleOutputW(handle, buf, new Coord() { X = height, Y = width }, new Coord() { X = 0, Y = 0 }, ref rect);
            }
        }

        public Cons(short offsetX, short offsetY, short width, short height)
        {
            handle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            this.width = width;
            this.height = height;
            if (!handle.IsInvalid)
            {
                buf = new CharInfo[height * width];
                rect = new SmallRect() { Left = offsetX, Top = offsetY, Right = (short)(width + offsetX), Bottom = (short)(height + offsetY) };
            }
        }
    }
}
