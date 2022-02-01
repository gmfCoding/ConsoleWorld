using Consoleworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FastConsole;

namespace CWEditorCLI
{
    class WorldBrush
    {
        Cons console = new Cons(0, 0, 50, 50);
        TileEditor editor;

        int index;
        TileInfo paint;

        int width;
        int height;

        int radius = 6;

        double curXR = 0.0;
        double curYR = 0.0;
        double speed = 10.0;

        int curX;
        int curY;

        TileInfo[,] world;

        public WorldBrush(TileEditor editor, int width, int height, TileInfo[,] world)
        {
            this.editor = editor;
            this.width = width;
            this.height = height;
            this.world = world;

            curY = height / 2;
            curX = width / 2;
        }

        public void Update()
        {
            Console.WriteLine("Drawing Mode!");
            bool finished = false;
            Stopwatch time = new Stopwatch();

            int frameCount = 0;
            while (!finished)
            {
                frameCount++;
                double dt = time.Elapsed.TotalSeconds;
                time.Restart();
                Console.CursorVisible = false;

                RenderUtil.RenderWorld(world, console);

                Input.Update();
                
                curXR = Util.Clamp(curXR, 0.0, width);
                curYR = Util.Clamp(curYR, 0.0, height);

                curX = Util.Clamp((int)curXR, 0, width);
                curY = Util.Clamp((int)curYR, 0, height);

                console.SetCursor(curX, curY);
                console.Write("+", ConsoleColor.Red);

                bool draw = false;
                if (Input.GetKey(KeyCode.Space))
                    draw = true;

                if (Input.GetKeyDown(KeyCode.Q))
                    radius--;
                if (Input.GetKeyDown(KeyCode.E))
                    radius++;



                void SetPaintByOffset(int offset)
                {
                    int ind = (index + offset) % editor.GetTileNames().Count;
                    if (editor.TryGetTile(editor.GetTileNames()[Math.Abs(ind)], out TileInfo tile))
                    {
                        index = ind;
                        paint = tile;
                    }
                }

                if (Input.GetKeyDown(KeyCode.SQBRACKLEFT))
                    SetPaintByOffset(1);
                else if (Input.GetKeyDown(KeyCode.SQBRACKRIGHT))
                    SetPaintByOffset(-1);


                if (paint != null)
                {
                    for (int i = curX - radius; i < curX + radius; i++)
                    {
                        for (int j = curY - radius; j < curY + radius; j++)
                        {
                            if (Util.IsInsideCircle(curX, curY, i, j, radius) && !Util.IsOutOfBounds(i, j, width, height))
                            {
                                console.SetCursor(i, j);
                                console.Write(paint.character, paint.colour, (frameCount % 20) > 5 ? paint.backgroundColour : ConsoleColor.DarkGray);
                                if (draw)
                                {
                                    world[i, j] = paint;
                                }
                            }
                        }
                    }
                }

                Console.BackgroundColor = ConsoleColor.Black;

                if (Input.GetKey(KeyCode.Left))
                {
                    curXR -= dt * speed;
                }

                if (Input.GetKey(KeyCode.Right))
                {
                    curXR += dt * speed;
                }

                if (Input.GetKey(KeyCode.Up))
                {
                    curYR -= dt * speed;
                }

                if (Input.GetKey(KeyCode.Down))
                {
                    curYR += dt * speed;
                }


                if (Input.GetKeyDown(KeyCode.X))
                {
                    finished = true;
                    break;
                }

                time.Stop();
            }
        }
    }
}
