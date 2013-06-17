using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class MapLoader
    {
        // Class fields


        // Properties
        // private static Dictionary<string, object> LoadedDict { get; private set; }
        private static AbstractMap2D LoadedMap { get; set; }

        // Methods
        public static AbstractMap2D Load(string mapName, string sourceType = "file/JSON")
        {
            ClearLoadedMap();
            switch (sourceType)
            {
                case "file/JSON":
                    MapLoader.LoadedMap = FileJSONMapLoader.Load(mapName);
                    break;
                case "hardcodedTest":
                    MapLoader.LoadedMap = HardcodedMapLoader.Load(mapName);
                    break;
                default:
                    throw new WrongSourceTypeException("The Source type: '{0}' is spelled incorrectly or such type does not exist.", sourceType);
            }


            return MapLoader.LoadedMap;
        }

        // Could be used for restarting the level - no need to reload the same map.
        public static AbstractMap2D GetInitialStateOfCurrentMap()
        {
            return MapLoader.LoadedMap;
        }


        // Clear the contents of the map dictionary
        private static void ClearLoadedMap()
        {
            LoadedMap.Clear();
        }
    }
}
