using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class MappackLoader
    {
        public static Dictionary<string, object> Load(string mappackName)
        {
            Dictionary<string, object> loadedMappack = new Dictionary<string, object>();

            string loadedData = LoadMappackWithFileName(mappackName);

            loadedMappack = ParseJSONMappackToNormalMappack.ParseJSONMappack(loadedData);

            return loadedMappack;
        }

        private static string LoadMappackWithFileName(string mapName)
        {
            string fileName = mapName;
            string fileType = ".txt";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Levels\\Mappacks\\";

            string loadedData = FileLoader.Load(fileName, fileType, filePath);

            return loadedData;
        }
    }
}
