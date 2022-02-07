using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consoleworld;

namespace CWEditorCLI
{
    class TileEditor : IEditor
    {
        Dictionary<string, TileInfo> tiles = new Dictionary<string, TileInfo>();
        Dictionary<TileInfo, bool> dirtyList = new Dictionary<TileInfo, bool>();

        CommandSelection commands = new CommandSelection(true);

        public TileEditor()
        {
            commands.RegisterCommand("edit", Edit);
            commands.RegisterCommand("create", Create);
            commands.RegisterCommand("view", View);
        }

        public void LoadFromPath(string path = null)
        {
            var loadedTiles = Resources.LoadTileDefinitions(path);
            foreach (var item in loadedTiles)
            {
                this.Add(item);
            }
        }

        public bool TryGetTile(string name, out TileInfo tile)
        {

            if (tiles.ContainsKey(name))
            {
                tile = tiles[name];
                return true;
            }
            tile = null;
            return false;
        }

        public TileInfo GetTile(string name)
        {
            if (tiles.ContainsKey(name))
            {
                return tiles[name];
            }
            return null;
        }

        public List<string> GetTileNames()
        {
            return tiles.Keys.ToList();
        }

        public void Add(TileInfo tile)
        {
            tiles.Add(tile.Name, tile);
        }

        private void View()
        {
            foreach (var tile in tiles.Values)
            {
                Conlog.WriteLine($"{tile.Name}:", ConsoleColor.Yellow);
                Conlog.WriteLine($"{tile.Character}{tile.Character}{tile.Character}", tile.Colour);
                Conlog.WriteLine($"{tile.Character}{tile.Character}{tile.Character}", tile.Colour);
                Conlog.WriteLine($"{tile.Character}{tile.Character}{tile.Character}", tile.Colour);
                Console.WriteLine();
            }
        }

        public void Edit(string name)
        {
            if (tiles.ContainsKey(name) == false)
            {
                Console.WriteLine("Couldn't find tile:{name}, would you like to create it?");
                Create(name);
            }
            TileInfo def = tiles[name];
            bool exit = false;
            while (!exit)
            {

            }
        }

        public void Create(string name)
        {
            tiles.Add(name, new TileInfo());
        }

        void Create()
        { 
        
        }

        public string GetName()
        {
            return "TileEditor";
        }

        public void Edit()
        {
            string tileName = Console.ReadLine();
        }

        public void Open()
        {
            commands.Help();
            Conz.WriteLine("#mode, The TileEditor mode.", ConsoleColor.DarkGray, once: true);
            while (!commands.exit)
            {
                commands.ReadLine("mode:", ConsoleColor.DarkCyan);
            }
        }

        public void SaveDirty()
        {
            foreach (var item in dirtyList.Keys)
            {
                if (dirtyList[item])
                {
                    Resources.SaveTileDefinition(item);
                }
            }
        }

        public void ForceSave()
        {
            foreach (var item in tiles.Values)
            {
                Resources.SaveTileDefinition(item);
            }
        }

        void Help()
        {
            Console.WriteLine("TileEditor: start by typing edit or create:");

        }
    }
}
