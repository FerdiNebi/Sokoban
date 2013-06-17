using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class Referee
    {
        public static bool CheckForWin(List<GameObject> targets, List<GameObject> boxes)
        {
            int collisionCount = 0;
            foreach (GameObject target in targets)
            {
                List<GameObject> currentCollisions = CollisionDetector.CheckForCollision(target, boxes);

                if (currentCollisions.Count > 0)
                {
                    collisionCount++;
                }
            }

            return targets.Count == collisionCount;
        }
    }
}
