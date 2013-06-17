using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Map
    {
        // Singleton
        private static readonly Map instance = new Map();

        public static Map Instance
        {
            get 
            {
                return instance; 
            }
        }

        // Class fields


        // Properties
        public Dictionary<string, List<GameObject>> ObjectDictionary { get; private set; }
        public Vector2D Size { get; private set; }
        public Vector2D OriginTopLeft { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public string Name { get; private set; }
        public int TimeLimit { get; private set; }   // Time limit to complete the level. If <= 0, then no limit
        public int MoveLimit { get; private set; }   // Move limit to complete the level. If <= 0, then no limit


        // Methods
        // --- Constructors
        private Map()
        {
            ConstructEmptyObjectDictionary();
            ClearMap();
        }

        // --- Init the Object Dictionary
        private void ConstructEmptyObjectDictionary()
        {
            this.ObjectDictionary = new Dictionary<string, List<GameObject>>();

            // Object Types
            this.ObjectDictionary[Player.CollisionGroupString] = new List<GameObject>();
            this.ObjectDictionary[Box.CollisionGroupString] = new List<GameObject>();
            this.ObjectDictionary[Wall.CollisionGroupString] = new List<GameObject>();
            this.ObjectDictionary[Target.CollisionGroupString] = new List<GameObject>();
        }


        // --- Clear Map
        public void ClearMap()
        {
            // Game Objects
            this.ObjectDictionary.Clear();

            // Size
            this.Size = Vector2D.ZeroVector;
            this.OriginTopLeft = Vector2D.ZeroVector;

            // Difficulty
            this.Difficulty = Difficulty.Unknown;

            // Name
            this.Name = "Sokoban Level";

            // Time
            this.TimeLimit = -1;

            // MoveLimit
            this.MoveLimit = -1;
        }


        // --- Load Map
        public void Load(string mapName, string sourceType = "file/JSON")
        {
            AbstractMap2D loadedMap = MapLoader.Load(mapName, sourceType);
            MapBuilderDirector(loadedMap);
        }

        // Build Map
        private void MapBuilderDirector(AbstractMap2D loadedMap)
        {
            Dictionary<string, object> buildedMap = MapBuilder.Build(loadedMap);

            // Assign the current map properties
            AssignProperties(buildedMap);
        }

        private void AssignProperties(Dictionary<string, object> buildedMap)
        {
            this.ObjectDictionary = (Dictionary<string, List<GameObject>>)buildedMap["GameObjects"];
            this.Size = (Vector2D)buildedMap["Size"];
            this.OriginTopLeft = (Vector2D)buildedMap["Origin"];
            this.Difficulty = (Difficulty)buildedMap["Difficulty"];
            this.Name = (string)buildedMap["Name"];
            this.TimeLimit = (int)buildedMap["TimeLimit"];
            this.MoveLimit = (int)buildedMap["MoveLimit"];
        }


        // Reset Map
        private void Reset()
        {
            Dictionary<string, object> rebuildedMap = MapBuilder.Rebuild();
            AssignProperties(rebuildedMap);
        }
    }
}
