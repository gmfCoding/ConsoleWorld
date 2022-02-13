using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastConsole;

namespace FConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FullHeightWidth();

            //Console.WriteLine("END OF PROGRAM");
            Console.ReadLine();
        }

        public static void FullHeightWidth()
        {
            FastConsoleInstance fci = new FastConsoleInstance(0, 0, (short)Console.BufferWidth, (short)Console.BufferHeight);
            fci.autoFlush = false;
            fci.processColours = true;

            //fci.Write("<blue>Hello, World!");
            Random random = new Random();
            //while (true)
            //{
            //    for (int y = 0; y < Console.WindowHeight; y++)
            //    {
            //        for (int x = 0; x < Console.WindowWidth; x++)
            //        {
            //            fci.WriteAt('⩯', x, y);
            //        }
            //    }
            //    fci.Flush();
            //}
            SystemCalls.CharInfo[] brData = new SystemCalls.CharInfo[10 * 10];
            BufferRegion br = new BufferRegion(brData, 10, 10);

            SystemCalls.CharInfo[] br2Data = new SystemCalls.CharInfo[10 * 10];
            BufferRegion br2 = new BufferRegion(br2Data, 10, 10, offset:new Coord(5,5));

            while (true)
            {
                for (int i = 0; i < brData.Length; i++)
                {
                    brData[i] = new SystemCalls.CharInfo() { Attributes = 15, Char = new SystemCalls.CharUnion() { UnicodeChar = (char)random.Next(33, 127) } };
                    br2Data[i] = new SystemCalls.CharInfo() { Attributes = 67, Char = new SystemCalls.CharUnion() { UnicodeChar = (char)random.Next(33, 127) } };
                }

                SystemCalls.WriteBufferRegion(br);
                System.Threading.Thread.Sleep(5);
                SystemCalls.WriteBufferRegion(br2);
            }


            //fci.Flush();
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            //for (int i = 0; i < Console.WindowHeight - 2; i++)
            //{
            //    fci.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());
            //}
        }
    }
}
