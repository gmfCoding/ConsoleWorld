using Consoleworld;
using FastConsole;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class WorldEditor : IEditor
    {
        string levelName;
        int areaID;
        TileInfo[,] tiles;

        int width;
        int height;

        WorldBrush brush;

        public WorldEditor()
        {
            tiles = new TileInfo[50, 50];
            brush = new WorldBrush(References.GetReference<TileEditor>("tile_editor"), 50, 50, tiles);
        }

        public string GetName()
        {
            return $"WorldEditor:{levelName}";
        }


        int curX;
        int curY;
        float timer;
            

        public void Open()
        {
           

            bool done = false;
            Stopwatch time = new Stopwatch();

            Cons console = new Cons(0, 0, 50, 50);
            while (!done)
            {
                double dt = time.Elapsed.TotalSeconds;
                timer += (float)dt;
                time.Restart();
                Console.CursorVisible = false;

                RenderUtil.RenderWorld(tiles, console);

                Input.Update();


                curX = Util.Clamp((int)curX, 0, width);
                curY = Util.Clamp((int)curY, 0, height);

                Console.BackgroundColor = ConsoleColor.Black;

                if (Input.GetKey(KeyCode.Left))
                {
                    curX++;
                }

                if (Input.GetKey(KeyCode.Right))
                {
                    curX++;
                }

                if (Input.GetKey(KeyCode.Up))
                {
                    curY++;
                }

                if (Input.GetKey(KeyCode.Down))
                {
                    curY++;
                }


                if (Input.GetKeyDown(KeyCode.X))
                {
                    done = true;
                    break;
                }
                //sb.Clear();
                time.Stop();

            }
        }

        void Create()
        {
            Console.WriteLine("Creating a new world, please specify info:");
            int width = ConReaders.widthReader.Read();
            int height = ConReaders.heightReader.Read();
            string worldName = ConReadConfirm.Read("Please enter a world name. \nName:");


        }
    }
}
