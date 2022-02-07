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

        int curX;
        int curY;

        InputPossiblities possiblities = new InputPossiblities(true, true);

        public WorldEditor()
        {
            possiblities.Add(new InputPossiblity(CreateWorldDialogue, "Create a new World.", "create", "new"));
            possiblities.Add(new InputPossiblity(OpenWorldDialogue, "Open a world to view/edit.", "open", "load"));
            tiles = new TileInfo[50, 50];
            brush = new WorldBrush(References.GetReference<TileEditor>("tile_editor"), 50, 50, tiles);
        }

        public string GetName()
        {
            return $"WorldEditor:{levelName}";
        }
            

        public void Open()
        {
            possiblities.Input();
        }

        /// <summary>
        /// Load a world dialogue
        /// </summary>
        void OpenWorldDialogue()
        {
            Console.WriteLine("World file path:");
        }


        /// <summary>
        /// Edit the currently loaded world
        /// </summary>
        void WorldEdit()
        {
            bool done = false;
            Cons console = new Cons(0, 0, 50, 50);
            BasicFrameTimer bft = new BasicFrameTimer();
            while (bft.Loop(out double dt))
            {
                brush.Update();
            }
        }

        /// <summary>
        /// View the currently loaded world
        /// </summary>
        void WorldViewer()
        {
            Cons console = new Cons(0, 0, 50, 50);
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

        void CreateWorldDialogue()
        {
            Console.WriteLine("Creating a new world, please specify:");
            string worldName = ConReadConfirm.Read("Please enter a world name. \nName:");
            int width = ConReaders.widthReader.Read();
            int height = ConReaders.heightReader.Read();
        }
    }
}
