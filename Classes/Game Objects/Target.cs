using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Target : StaticObject
    {
        public new const string CollisionGroupString = "target";


        // Methods
        // --- Constructors
        public Target(Vector2D position) : base(position)
        {
            this.body = 'x';
        }


        // --- Overrided Methods
        public override string GetCollisionGroupString()
        {
            return Target.CollisionGroupString;
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
