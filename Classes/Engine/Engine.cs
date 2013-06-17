using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NotJustSokoban
{
    public class Engine
    {
        private Dictionary<string, List<GameObject>> allObjectsOriginal;
        private Dictionary<string, List<GameObject>> allObjects;
        private IRenderer renderer;
        private IUserInterface userInterface;
        private const int NumberPushableBoxes = 1; //Number of boxes "player" can push at the same time
        private int levelCount;
        private bool hasPlayerWon;
        private bool hasBeenRendered;
        private bool levelHasTimer;
        private Timer timer;
        private int timerLastValue;

        public Engine(Dictionary<string, List<GameObject>> allObjects, IRenderer renderer, IUserInterface userInterface, int levelCount, Timer time, bool levelHasTimer)
        {
            this.allObjectsOriginal = allObjects;
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.hasPlayerWon = false;
            this.hasBeenRendered = false;
            this.levelCount = levelCount;
            this.timer = time;
            this.timerLastValue = 0;
            this.levelHasTimer = levelHasTimer;
            Reset();
        }

        //Run method
        public void Run()
        {
            while (!hasPlayerWon)
            {
                if (!hasBeenRendered)
                {
                    RenderAllObjects();
                    hasBeenRendered = true;
                }
                userInterface.ProcessInput();
                DisplayTimer();
            }
        }

        //MoveXXXX - iniciates movement of game objects
        public void MoveLeft(int playerType)
        {
            PerformMove(new Vector2D(-1, 0), playerType);
        }

        public void MoveRight(int playerType)
        {
            PerformMove(new Vector2D(1, 0), playerType);
        }
        public void MoveUp(int playerType)
        {
            PerformMove(new Vector2D(0, -1), playerType);
        }
        public void MoveDown(int playerType)
        {
            PerformMove(new Vector2D(0, 1),playerType);
        }

        //Wrapper method for all methods executed when objects move
        private void PerformMove(Vector2D direction, int playerType)
        {
            HandleCollisions(direction,playerType);
            DetermineTargetVisibility();
            RenderAllObjects();
            hasPlayerWon = Referee.CheckForWin(allObjects["target"], allObjects["box"]);
        }

        //Move objects according to collision occurrence
        private void HandleCollisions(Vector2D direction, int playerType)
        {
            //Get a player refference
            Player player;    
            if (allObjects.Keys.Contains("player"))
            {
                if (playerType != 0)
                {
                    if (allObjects["player"].Count <= 1)
                    {
                        return;
                    }
                    player = (Player)allObjects["player"][playerType % 2];
                }
                else
                {
                    player = (Player)allObjects["player"][0];
                }
            }
            else
            {
                throw new ArgumentException("No players in game");
            }

            List<GameObject> movingObjects = new List<GameObject>(); //Objects that are enqueued to be moved
            List<GameObject> movedObjects = new List<GameObject>();  //Objects that have already been moved

            movingObjects.Add(player);
            int count = 0; // Number of boxes that have once been added to movingObjects list.
            bool collisionFound = false;

            //Perform moving objects
            while (movingObjects.Count > 0 && count <= NumberPushableBoxes && !collisionFound)
            {
                MoveableObject objectToMove = (MoveableObject)movingObjects.ElementAt(0); //Take the first object that has to be moved
                movingObjects.RemoveAt(0); //Remove that object from the list
                objectToMove.Move(direction); //Move the object
                movedObjects.Add(objectToMove); //Add the object to movedObjects list
                List<GameObject> walls = CollisionDetector.CheckForCollision(objectToMove, allObjects["wall"]); //Check for collisions with walls
                List<GameObject> otherPlayers = CollisionDetector.CheckForCollision(objectToMove, allObjects["player"]); //Check for collisions with other players

                if (walls.Count > 0 || otherPlayers.Count > 0)
                {
                    collisionFound = true;
                }

                List<GameObject> boxes = CollisionDetector.CheckForCollision(objectToMove, allObjects["box"]); //Check for collisions with boxes
                movingObjects.AddRange(boxes);
                count += boxes.Count;
            }

            //Check if moving objects is valid. If not - move them back.
            if (movingObjects.Count > 0 || collisionFound)
            {
                Vector2D oppositeDirection = direction * (-1);
                foreach (MoveableObject obj in movedObjects) //Could occur problem because movedObjects are GameObjects
                {
                    obj.Move(oppositeDirection);
                }
            }
        }

        //Makes targets invisible if they colide with a box or a player
        private void DetermineTargetVisibility()
        {
            foreach (Target target in allObjects["target"])
            {
                target.IsVisible = true;

                List<GameObject> collidingBoxes = CollisionDetector.CheckForCollision(target, allObjects["box"]);
                List<GameObject> collidingPlayers = CollisionDetector.CheckForCollision(target, allObjects["player"]);

                if (collidingBoxes.Count > 0 || collidingPlayers.Count > 0)
                {
                    target.IsVisible = false;
                }
            }
        }

        //Renders all objects that have to be rendered on every move using IRenderer object
        private void RenderAllObjects()
        {
            //Enqueue for rendering
            foreach (string objectType in allObjects.Keys)
            {
                if (objectType != "target")
                {
                    foreach (GameObject obj in allObjects[objectType])
                    {
                        renderer.EnqueueForRender(obj);
                    }
                }
                else
                {
                    foreach (Target target in allObjects[objectType])
                    {
                        if (target.IsVisible)
                        {
                            renderer.EnqueueForRender(target);
                        }
                    }
                }
            }
            //Render
            renderer.RenderAll();
            //Clear queue
            renderer.ClearQueue();
            //Print level info
            renderer.DisplayLevel(this.levelCount);
            //Print controls info
            renderer.DisplayShowControls();
        }

        /// <summary>
        /// Resets all game objects inital position in the given level
        /// </summary>
        public void Reset()
        {
            allObjects = new Dictionary<string, List<GameObject>>();
            allObjects["wall"] = new List<GameObject>();
            allObjects["player"] = new List<GameObject>();
            allObjects["target"] = new List<GameObject>();
            allObjects["box"] = new List<GameObject>();

            int playerCount = 0;
            foreach (string type in allObjectsOriginal.Keys)
            {
                foreach (GameObject gameObject in allObjectsOriginal[type])
                {
                    switch (type)
                    {
                        case "wall": allObjects["wall"].Add(new Wall(gameObject.GetPosition())); break;
                        case "player": allObjects["player"].Add(new Player(gameObject.GetPosition(), playerCount)); playerCount++; break;
                        case "box": allObjects["box"].Add(new Box(gameObject.GetPosition())); break;
                        case "target": allObjects["target"].Add(new Target(gameObject.GetPosition())); break;
                        default: break;
                    }
                }
            }

            RenderAllObjects();
        }

        /// <summary>
        /// Checks if time is up. If not - displays the timer
        /// </summary>
        /// <exception cref="TimeoutException"></exception>
        public void DisplayTimer()
        {
            if (this.timerLastValue != this.timer.Time)
            {
                this.timerLastValue = this.timer.Time;
                if (this.levelHasTimer)
                {
                    //Display timer.Time 
                    renderer.DisplayTimer(this.timer.Time);
                    //Check if time is up
                    if (this.timer.Time <= 0)
                    {
                        throw new TimeoutException("Time is up!");
                    }
                }
                else
                {
                    renderer.DisplayTimer(0);
                }
            }
        }
    }
}
