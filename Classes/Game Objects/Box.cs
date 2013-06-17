using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Box : MoveableObject
    {

        public new const string CollisionGroupString = "box";


        // Methods
        // --- Constructors
        public Box(Vector2D position) : base(position)
        {
            this.body = '\u25a0';
        }


        // --- Overrided Methods
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "wall" || otherCollisionGroupString == "player" || otherCollisionGroupString == "target" || otherCollisionGroupString == "box";
        }

        public override string GetCollisionGroupString()
        {
            return Box.CollisionGroupString;
        }

        //public override void RespondToCollision(CollisionData collisionData)
        //{
            
        //}
    }
}
