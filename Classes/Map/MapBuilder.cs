using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class MapBuilder
    {
        // Class fields

        // Properties
        private static AbstractMap2D AbstractMap { get; set; }

        // Methods
        public static Dictionary<string, object> Build(AbstractMap2D abstractMap)
        {
            MapBuilder.AbstractMap = abstractMap;
            Dictionary<string, object> buildedMapDict = new Dictionary<string, object>();
            buildedMapDict["Difficulty"] = BuildDifficulty();
            buildedMapDict["Size"] = BuildSize();
            buildedMapDict["Origin"] = BuildOrigin();
            buildedMapDict["GameObjects"] = BuildGameObjects();
            buildedMapDict["Name"] = BuildName();
            buildedMapDict["TimeLimit"] = BuildTimeLimit();
            buildedMapDict["MoveLimit"] = BuildMoveLimit();

            return buildedMapDict;
        }


        // Building parts
        private static Difficulty BuildDifficulty()
        {
            string strDifficulty = MapBuilder.AbstractMap.Difficulty;
            Difficulty difficulty = Difficulty.Unknown;

            switch (strDifficulty.ToLower())
            {
                case "easy":
                    difficulty = Difficulty.Easy;
                    break;
                case "moderate":
                    difficulty = Difficulty.Moderate;
                    break;
                case "hard":
                    difficulty = Difficulty.Hard;
                    break;
                case "insane":
                    difficulty = Difficulty.Insane;
                    break;
                case "test":
                    difficulty = Difficulty.Test;
                    break;
                case "unknown":
                default:
                    difficulty = Difficulty.Unknown;
                    break;

            }

            return difficulty;
        }

        private static Vector2D BuildSize()
        {
            int width = MapBuilder.AbstractMap.Size[0];
            int height = MapBuilder.AbstractMap.Size[1];
            Vector2D size = new Vector2D(width, height);

            return size;
        }

        private static Vector2D BuildOrigin()
        {
            int x = MapBuilder.AbstractMap.Origin[0];
            int y = MapBuilder.AbstractMap.Origin[1];
            Vector2D origin = new Vector2D(x, y);

            return origin;
        }

        private static Dictionary<string, List<GameObject>> BuildGameObjects()
        {
            Dictionary<string, List<GameObject>> gameObjects = new Dictionary<string, List<GameObject>>();

            // Build the GameObjects Dict
            gameObjects["player"] = BuildPlayerObjectsList();
            gameObjects["box"] = BuildBoxObjectsList();
            gameObjects["target"] = BuildTargetObjectsList();
            gameObjects["wall"] = BuildWallObjectsList();


            return gameObjects;
        }

        private static List<GameObject> BuildWallObjectsList()
        {
            List<GameObject> objectsList = new List<GameObject>();

            foreach (int[] objParams in MapBuilder.AbstractMap.GameObjects["wall"])
            {
                int x = objParams[0];
                int y = objParams[1];
                Vector2D coordinates = new Vector2D(x, y);
                objectsList.Add(new Wall(coordinates));
            }

            return objectsList;
        }

        private static List<GameObject> BuildTargetObjectsList()
        {
            List<GameObject> objectsList = new List<GameObject>();

            foreach (int[] objParams in MapBuilder.AbstractMap.GameObjects["target"])
            {
                int x = objParams[0];
                int y = objParams[1];
                Vector2D coordinates = new Vector2D(x, y);
                objectsList.Add(new Target(coordinates));
            }

            return objectsList;
        }

        private static List<GameObject> BuildBoxObjectsList()
        {
            List<GameObject> objectsList = new List<GameObject>();

            foreach (int[] objParams in MapBuilder.AbstractMap.GameObjects["box"])
            {
                int x = objParams[0];
                int y = objParams[1];
                Vector2D coordinates = new Vector2D(x, y);
                objectsList.Add(new Box(coordinates));
            }

            return objectsList;
        }

        private static List<GameObject> BuildPlayerObjectsList()
        {
            List<GameObject> objectsList = new List<GameObject>();

            foreach (int[] objParams in MapBuilder.AbstractMap.GameObjects["player"])
            {
                int x = objParams[0];
                int y = objParams[1];
                Vector2D coordinates = new Vector2D(x, y);
                objectsList.Add(new Player(coordinates, MapBuilder.AbstractMap.GameObjects["player"].Count));
            }

            return objectsList;
        }

        private static string BuildName()
        {
            string name = MapBuilder.AbstractMap.Name;
            return name;
        }

        private static int BuildTimeLimit()
        {
            int timeLimit = MapBuilder.AbstractMap.TimeLimit;
            return timeLimit;
        }

        private static int BuildMoveLimit()
        {
            int moveLimit = MapBuilder.AbstractMap.MoveLimit;
            return moveLimit;
        }


        // Used for rebuild
        public static Dictionary<string, object> Rebuild()
        {
            Dictionary<string, object> rebuildedMap = MapBuilder.Build(MapBuilder.AbstractMap);

            return rebuildedMap;
        }
    }
}
