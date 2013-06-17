using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class FileJSONMapLoader
    {
        public static AbstractMap2D Load(string mapName)
        {
            AbstractMap2D loadedMap = new AbstractMap2D();

            string loadedData = LoadMapWithFileName(mapName);

            loadedMap = ParseJSONMapToAbstractMap2D.ParseJSONMap(loadedData);

            return loadedMap;
        }

        private static string LoadMapWithFileName(string mapName)
        {
            string fileName = mapName;
            string fileType = ".txt";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Levels\\FileLevels\\";

            string loadedData = FileLoader.Load(fileName, fileType, filePath);

            return loadedData;
        }
    }
}
