using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    // Use this struct to pass it between Map-related Classes, before the actual map is build
    public struct AbstractMap2D
    {
        // Struct Fields
        private Dictionary<string, List<int[]>> gameObjects;
        private int[] size;
        private int[] origin;
        private string difficulty;
        private string name;
        private int timeLimit;
        private int moveLimit;



        // Properties
        public Dictionary<string, List<int[]>> GameObjects
        {
            get
            {
                return this.gameObjects;
            }
        }

        public int[] Size
        {
            get
            {
                return this.size;
            }
        }

        public int[] Origin
        {
            get
            {
                return this.origin;
            }
        }

        public string Difficulty
        {
            get
            {
                return this.difficulty;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int TimeLimit
        {
            get
            {
                return this.timeLimit;
            }
        }

        public int MoveLimit
        {
            get
            {
                return this.moveLimit;
            }
        }

        // Methods
        // --- Constructor
        public AbstractMap2D(string name, Dictionary<string, List<int[]>> gameObjects, int[] size, int[] origin, string difficulty, int timeLimit, int moveLimit)
        {
            this.gameObjects = gameObjects;
            this.size = size;
            this.origin = origin;
            this.difficulty = difficulty;
            this.name = name;
            this.timeLimit = timeLimit;
            this.moveLimit = moveLimit;
        }


        // 
        public void Clear()
        {
            if (this.gameObjects != null)
            {
                this.gameObjects.Clear();
            }
            
            
            this.size = new int[] { 0, 0 };
            this.origin = new int[] { 0, 0 };
            this.difficulty = "unknown";
            this.name = "Unknown level";
        }
    }
}
