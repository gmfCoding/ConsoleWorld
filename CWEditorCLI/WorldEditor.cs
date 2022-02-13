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
    public class WorldEditor : IEditor
    {
        string levelName;
        int areaID;

        int width;
        int height;

        TileInfo[,] tiles;

        bool worldLoaded = false;

        WorldBrush brush;

        int curX;
        int curY;

        InputPossiblities possiblities = new InputPossiblities(true, true);

        public WorldEditor()
        {
            possiblities.Add(new InputPossiblity("create", "Create a new World.", CreateWorldDialogue, ConsoleColor.Yellow));
            possiblities.Add(new InputPossiblity("load", "Open a world to view/edit.", OpenWorldDialogue, ConsoleColor.Yellow));
        }

        public string GetName()
        {
            return $"WorldEditor:{levelName}";
        }
            
        public void Open()
        {
            possiblities.PrintHelp();
            possiblities.Input();
        }

        /// <summary>
        /// Load a world dialogue
        /// </summary>
        void OpenWorldDialogue()
        {
            FConsole.WriteLine("World file path:");
        }


        /// <summary>
        /// Edit the currently loaded world
        /// </summary>
        public void WorldEdit()
        {
            if (worldLoaded)
            {
                FastConsoleInstance console = new FastConsoleInstance(0, 0, 50, 50);
                BasicFrameTimer bft = new BasicFrameTimer();
                while (bft.Loop(out double dt))
                {
                    brush.Update();
                }
            }
            else
            {
                FConsole.WriteLine("<red>Unable to edit world as there is no currently loaded world.");
            }
        }

        /// <summary>
        /// View the currently loaded world
        /// </summary>
        void WorldViewer()
        {
            if (worldLoaded)
            {
                FastConsoleInstance console = new FastConsoleInstance(0, 0, 50, 50);
                BasicFrameTimer bft = new BasicFrameTimer();
                while (bft.Loop(out double dt))
                {
                    Console.CursorVisible = false;
                    RenderUtil.RenderWorld(tiles, console);

                    Input.Update();

                    curX = Util.Clamp((int)curX, 0, width);
                    curY = Util.Clamp((int)curY, 0, height);


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
                        bft.Exit();
                        break;
                    }
                }
            }
            else
            {
                FConsole.WriteLine("<red>Unable to view world as there is no currently loaded world.");
            }
        }

        void CreateWorldDialogue()
        {
            FConsole.WriteLine("<green>Creating a new world, please specify:");
            string worldName = ConReadConfirm.Read("WorldName:");

            int width = ConReaders.intReader.Read("width:");
            int height = ConReaders.intReader.Read("height:");

            tiles = new TileInfo[height, width];
            FConsole.WriteLine($"{ColourStyles.say}Created world:{ColourStyles.world}{worldName} {ColourStyles.ask}size:<blue>{width}<white>x<blue>{height}.");

            levelName = worldName;
            areaID = worldName.GetHashCode();
            brush = new WorldBrush(EditorInstance.Get().tile, width, height, tiles);
        }
    }
}
