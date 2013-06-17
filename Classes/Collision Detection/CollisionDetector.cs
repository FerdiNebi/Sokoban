using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{

    public static class CollisionDetector
    {
        ///<summary> Checks for collisions between a GameObject and List of GameObject</summary>
        ///<returns>List of objects colliding with the given one</returns>
        public static List<GameObject> CheckForCollision(GameObject lastMovedObject, List<GameObject> otherObjects)
        {
            List<GameObject> collidingObjects = new List<GameObject>();
            Vector2D lastMovedObjectPosition = lastMovedObject.GetPosition();

            foreach (GameObject obj in otherObjects)
            {
                Vector2D currentObjectPosition = obj.GetPosition();
                if (lastMovedObject.CanCollideWith(obj.GetCollisionGroupString()) &&
                    lastMovedObjectPosition.X == currentObjectPosition.X &&
                    lastMovedObjectPosition.Y == currentObjectPosition.Y &&
                    lastMovedObject != obj)
                {
                    collidingObjects.Add(obj);
                }
            }

            return collidingObjects;
        }
        
    }
}