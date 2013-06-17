using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class ParseJSONMapToAbstractMap2D
    {
        public static AbstractMap2D ParseJSONMap(string jsonText)
        {
            // Get the JSON Object
            JObject jsonData = JObject.Parse(jsonText);

            string mapName = ParseName(jsonData);
            int[] size = ParseSize(jsonData);
            int[] origin = ParseOrigin(jsonData);
            string difficulty = ParseDifficulty(jsonData);
            int timeLimit = ParseTimeLimit(jsonData);
            int moveLimit = ParseMoveLimit(jsonData);

            // Game Objects
            Dictionary<string, List<int[]>> gameObjects = ParseGameObjects(jsonData);


            // Create the AbstractMap
            AbstractMap2D parsedAbstractMap = new AbstractMap2D(mapName, gameObjects, size, origin, difficulty, timeLimit, moveLimit);

            return parsedAbstractMap;
        }

        private static string ParseName(JObject jsonObject)
        {
            JToken nameToken = jsonObject["metadata"]["name"];

            string mapName = JTokenToTypeConverter.ParseTokenToString(nameToken);

            return mapName;
        }

        private static int[] ParseSize(JObject jsonObject)
        {
            IList<JToken> sizeTokens = jsonObject["levelData"]["size"].Children().ToList();

            int[] mapSize = JTokenToTypeConverter.ParseTokenToIntArray(sizeTokens);

            return mapSize;
        }

        private static int[] ParseOrigin(JObject jsonObject)
        {
            IList<JToken> originTokens = jsonObject["levelData"]["origin"].Children().ToList();

            int[] mapOrigin = JTokenToTypeConverter.ParseTokenToIntArray(originTokens);

            return mapOrigin;
        }


        private static string ParseDifficulty(JObject jsonObject)
        {
            JToken difficultyToken = jsonObject["levelData"]["difficulty"];

            string mapDifficulty = JTokenToTypeConverter.ParseTokenToString(difficultyToken);

            return mapDifficulty;
        }

        private static int ParseTimeLimit(JObject jsonObject)
        {
            JToken timeLimitToken = jsonObject["levelData"]["timeLimit"];

            int mapTimeLimit = JTokenToTypeConverter.ParseTokenToInt(timeLimitToken);

            return mapTimeLimit;
        }

        private static int ParseMoveLimit(JObject jsonObject)
        {
            JToken moveLimitToken = jsonObject["levelData"]["moveLimit"];

            int mapMoveLimit = JTokenToTypeConverter.ParseTokenToInt(moveLimitToken);

            return mapMoveLimit;
        }

        private static Dictionary<string, List<int[]>> ParseGameObjects(JObject jsonObject)
        {
            JToken gameObjectsToken = jsonObject["gameObjects"];

            Dictionary<string, List<int[]>> mapGameObjects = new Dictionary<string, List<int[]>>();

            foreach (IList<JToken> listOfObjectsToken in gameObjectsToken)
            {
                string objectType = ((JProperty)listOfObjectsToken).Name.ToString();
                mapGameObjects[objectType] = new List<int[]>();

                foreach (IList<JToken> objectToken in listOfObjectsToken)
                {
                    foreach (IList<JToken> coordinatesToken in objectToken)
                    {
                        int[] objectCoordinates = JTokenToTypeConverter.ParseTokenToIntArray(coordinatesToken);

                        mapGameObjects[objectType].Add(objectCoordinates.ToArray());
                    }
                }
            }

            return mapGameObjects;
        }
    }
}
