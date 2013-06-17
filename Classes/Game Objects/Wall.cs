using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Wall : StaticObject
    {
        public new const string CollisionGroupString = "wall";


        // Methods
        // --- Constructors
        public Wall(Vector2D position) : base(position)
        {
            this.body = '\u2593';
        }


        // --- Overrided Methods
        public override string GetCollisionGroupString()
        {
            return Wall.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "player" || otherCollisionGroupString == "box";
        }

        //public override void RespondToCollision(CollisionData collisionData)
        //{
            
        //}
    }
}
