using FastConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO:
            // Figure out why saving and loading for the world tiles is incorrect
            // Currently Saving a world, then loading it back up has different results.
            // Is it to do with the direction that the world is saved in?
            // Is the unique tile id compression approach just bad?

            MapGenerator mgen = new MapGenerator();
            mgen.mapHeight = 100;
            mgen.mapWidth = 100;
            mgen.lacunarity = 3;
            mgen.noiseScale = 0.1f;
            mgen.persistance = 0.3f;
            mgen.offsetX = 100;
            mgen.offsetY = 100;
            mgen.octaves = 3;
            mgen.regions = new TerrainType[]
            {
                new TerrainType() { name = '~', height = 0.5f, colour = new ColourPair(ConsoleColor.Blue, ConsoleColor.DarkBlue)},
                new TerrainType() { name = '#', height = 0.55f, colour = new ColourPair(ConsoleColor.DarkYellow, ConsoleColor.Yellow)},
                new TerrainType() { name = '"', height = 0.7f, colour = new ColourPair(ConsoleColor.Green, ConsoleColor.DarkGreen)},
                new TerrainType() { name = '#', height = 0.8f, colour = new ColourPair(ConsoleColor.Gray, ConsoleColor.DarkGray)},
                new TerrainType() { name = '^', height = 0.9f, colour = new ColourPair(ConsoleColor.White, ConsoleColor.DarkGray)}
            };

            mgen.GenerateMap();

            Console.ReadLine();

            TileManager.LoadTilesFromPath();

            {
                World gen = new World();
                gen.Init("example_world", 3, 3);
                FastConsoleInstance cons = new FastConsoleInstance(0, 0, (short)gen.Width, (short)gen.Height);
                //gen.Randomise();
                gen.Fill(TileManager.Get("water"));
                gen.world[1, 1] = TileManager.Get("sand");

                SaveWorld(gen, "example_world");

                WorldRenderer.RenderWorld(gen, cons);

                cons.Flush();

                FConsole.ReadLine();
            }

            World world;
            
            TryLoadWorld("example_world", out world);
            FastConsoleInstance console = new FastConsoleInstance(0, 0, (short)world.Width, (short)world.Height);


            while (true)
            {
                WorldRenderer.RenderWorld(world, console);

                console.Flush();
            }

        }

        static bool TryLoadWorld(string path, out World world)
        {
            world = new World();

            using (FileStream fs = File.OpenRead(IOPaths.FullPath(path)))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    world.Read(br);
                    return true;
                }
            }

            return false;
        }

        static void SaveWorld(World world, string path)
        {
            using (FileStream fs = File.Create(IOPaths.FullPath(path)))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    world.Write(bw);
                }
            }
        }
    }
}
