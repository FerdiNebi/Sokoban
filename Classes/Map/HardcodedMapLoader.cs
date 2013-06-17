using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NotJustSokoban
{
    public static class HardcodedMapLoader
    {
        // Class fields
        



        // Properties
        private static string MapName { get; set; }
        private static Dictionary<char, string> CharToObjectTypesDict
        {
            get
            {
                return new Dictionary<char,string>()
                {
                    {' ' , "empty"},
                    {'#' , "wall"},
                    {'X' , "target"},
                    {'B' , "box"},
                    {'1' , "player"},
                    {'2' , "player"},
                    {'3' , "player"},
                    {'4' , "player"},
                    {'5' , "player"},
                    {'6' , "player"},
                    {'7' , "player"},
                    {'8' , "player"},
                    {'9' , "player"},
                };
            }
        }


        // Methods
        public static AbstractMap2D Load(string mapName)
        {
            HardcodedMapLoader.MapName = mapName;

            Dictionary<string, object> loadedDict = LoadMapMatrix(mapName);

            AbstractMap2D loadedMap = ParseMapFromCharMatix(loadedDict);

            return loadedMap;
        }

        


        private static Dictionary<string, object> LoadMapMatrix(string mapName)
        {
            // Type mapType = Type.GetType(mapName);

            char[,] charMap;
            int timeLimit = -1;
            int moveLimit = -1;

            /* char[,] charMap = (char[,]) mapType.InvokeMember(
                "Map",
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static,
                null,
                null,
                null);
            */

            
            switch (HardcodedMapLoader.MapName)
            {
                case "TestLevel1":
                    charMap = TestLevel1.Map;
                    timeLimit = TestLevel1.TimeLimit;
                    moveLimit = TestLevel1.MoveLimit;
                    break;
                case "TestLevel2":
                    charMap = TestLevel2.Map;
                    timeLimit = TestLevel2.TimeLimit;
                    moveLimit = TestLevel2.MoveLimit;
                    break;
                case "TestLevel3":
                    charMap = TestLevel3.Map;
                    timeLimit = TestLevel3.TimeLimit;
                    moveLimit = TestLevel3.MoveLimit;
                    break;
                case "TestLevel4":
                    charMap = TestLevel4.Map;
                    timeLimit = TestLevel4.TimeLimit;
                    moveLimit = TestLevel4.MoveLimit;
                    break;
                case "TestLevel5":
                    charMap = TestLevel5.Map;
                    timeLimit = TestLevel5.TimeLimit;
                    moveLimit = TestLevel5.MoveLimit;
                    break;
                case "TestLevel6":
                    charMap = TestLevel6.Map;
                    timeLimit = TestLevel6.TimeLimit;
                    moveLimit = TestLevel6.MoveLimit;
                    break;
                case "TestLevel7":
                    charMap = TestLevel7.Map;
                    timeLimit = TestLevel7.TimeLimit;
                    moveLimit = TestLevel7.MoveLimit;
                    break;
                default:
                    throw new WrongMapNameException("The map name: '{0}' is spelled incorrectly or such map does not exist.",
                        HardcodedMapLoader.MapName);
            }
            
            HardcodedMapLoader.MapName = mapName;

            Dictionary<string, object> loadedDict = new Dictionary<string, object>();
            loadedDict["Map"] = charMap;
            loadedDict["TimeLimit"] = timeLimit;
            loadedDict["MoveLimit"] = timeLimit;

            return loadedDict;
        }


        private static AbstractMap2D ParseMapFromCharMatix(Dictionary<string, object> mapDict)
        {
            // Init Map meta properties
            char[,] charMap = (char[,])mapDict["Map"];
            int[] origin = new int[] { 0, 0 };
            int[] size = new int[] { charMap.GetLength(1), charMap.GetLength(0) };
            string difficulty = "test";
            string name = "Test Level";
            int timeLimit = (int)mapDict["TimeLimit"];
            int moveLimit = (int)mapDict["MoveLimit"];

            Dictionary<string, List<int[]>> gameObjects = new Dictionary<string, List<int[]>>();


            for (int y = 0; y < charMap.GetLength(0); y++)
            {
                for (int x = 0; x < charMap.GetLength(1); x++)
                {

                    string type = "";
                    char charSymbol = charMap[y, x];
                    if (CharToObjectTypesDict.ContainsKey(charSymbol))
                    {
                        type = CharToObjectTypesDict[charSymbol];
                        int[] objectCoordinates = new int[]{x, y};
                        if (!gameObjects.ContainsKey(type))
                        {
                            gameObjects[type] = new List<int[]>();
                        }
                        gameObjects[type].Add(objectCoordinates);
                    }
                    else
                    {
                        throw new UnknownSymbolInHardcodedMapException("Unknown char symbol: '{0}' in Hardcoded map: '{1}'",
                            charSymbol, HardcodedMapLoader.MapName);
                    }
                }
            }

            AbstractMap2D parsedMap = new AbstractMap2D(name, gameObjects, size, origin, difficulty, timeLimit, moveLimit);

            return parsedMap;
        }
    }
}
