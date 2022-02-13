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
        FastConsoleInstance console = new FastConsoleInstance(0, 0, 50, 50);
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
            FConsole.WriteLine("Drawing Mode!");

            int frameCount  = 0;
            BasicFrameTimer bft = new BasicFrameTimer();
            while (bft.Loop(out double dt))
            {
                frameCount++;
                Console.CursorVisible = false;

                bft.Stop();
                RenderUtil.RenderWorld(world, console);
                Input.Update();
                bft.Start();
                
                curXR = Util.Clamp(curXR, 0.0, width);
                curYR = Util.Clamp(curYR, 0.0, height);

                curX = Util.Clamp((int)curXR, 0, width);
                curY = Util.Clamp((int)curYR, 0, height);

                console.SetCursor(curX, curY);
                console.Write("+", ConsoleColor.Red);

                bool draw = false;
                if (Input.GetKey(KeyCode.Space))
                    draw = true;

                Input_Radius();
                Input_Paint(draw, frameCount);
                Input_Position(dt);

                if (Input.GetKeyDown(KeyCode.X))
                {
                    bft.Exit();
                    break;
                }
            }
        }

        void SetPaintByOffset(int offset)
        {
            int ind = (index + offset) % editor.GetTileNames().Count;
            if (editor.TryGetTile(editor.GetTileNames()[Math.Abs(ind)], out TileInfo tile))
            {
                index = ind;
                paint = tile;
            }
        }

        void Input_SelectPaint()
        {
            if (Input.GetKeyDown(KeyCode.SQBRACKLEFT))
                SetPaintByOffset(1);
            else if (Input.GetKeyDown(KeyCode.SQBRACKRIGHT))
                SetPaintByOffset(-1);
        }

        void Input_Paint(bool paint, int frameCount)
        {
            PreviewOrPaint(paint, frameCount, 20, 5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paint">Whether or not to apply the paint </param>
        /// <param name="curFrameCount">The current amount of frames that have been rendered since the begining.</param>
        /// <param name="frameCountOff">The amount of frames the preview is off.</param>
        /// <param name="frameCountOn">The amount of frames the preview is on.</param>
        void PreviewOrPaint(bool paint, int curFrameCount, int frameCountOff, int frameCountOn)
        {
            if (this.paint != null)
            {
                for (int i = curX - radius; i < curX + radius; i++)
                {
                    for (int j = curY - radius; j < curY + radius; j++)
                    {
                        if (Util.IsInsideCircle(curX, curY, i, j, radius) && !Util.IsOutOfBounds(i, j, width, height))
                        {
                            console.SetCursor(i, j);
                            console.Write(this.paint.Character, new ColourPair(this.paint.Colour, (curFrameCount % frameCountOff) > frameCountOn ? this.paint.BackgroundColour : ConsoleColor.DarkGray));
                            if (paint)
                            {
                                world[i, j] = this.paint;
                            }
                        }
                    }
                }
            }
        }

        void Pan()
        { 
        
        }

        void Input_Radius()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                radius--;
            if (Input.GetKeyDown(KeyCode.E))
                radius++;
        }

        void Input_Position(double dt)
        {
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
        }
    }
}
