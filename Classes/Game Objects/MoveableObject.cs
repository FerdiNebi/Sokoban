using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class MoveableObject : GameObject
    {
        protected MoveableObject(Vector2D position)
            :base(position)
        {
           
        }

        //Create public method "Move(Vector2D direction)" to move the object in the given direction
        public virtual void Move(Vector2D direction)
        {
            if (direction.X <= 1 && direction.X >= -1 && direction.Y <= 1 && direction.Y >= -1)
            {
                position += direction;
            }
        }
    }
}
