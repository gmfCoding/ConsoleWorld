using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PeakConsole
{
    class Program
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool PeekConsoleInput(IntPtr hConsoleOutput, out InputRecord[] lpBuffer,uint nLength,out uint lpNumberOfEventsRead);


        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
string fileName,
[MarshalAs(UnmanagedType.U4)] uint fileAccess,
[MarshalAs(UnmanagedType.U4)] uint fileShare,
IntPtr securityAttributes,
[MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
[MarshalAs(UnmanagedType.U4)] int flags,
IntPtr template);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            //SafeFileHandle handle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            IntPtr handle = GetConsoleWindow();
            InputRecord[] records = new InputRecord[1];


            while (true)
            {
                PeekConsoleInput(handle, out records, 1, out uint lpNumber);
                if (records != null)
                {
                    foreach (var item in records)
                    {
                        if (item.eventType != 0)
                        {
                            Console.WriteLine("Something!");
                        }
                    }
                }
            }
        }
    }
}
