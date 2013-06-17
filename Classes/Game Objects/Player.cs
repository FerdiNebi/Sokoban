using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotJustSokoban.Classes.Game_Objects;

namespace NotJustSokoban
{
    public class Player : MoveableObject
    {
        // Class fields
        public new const string CollisionGroupString = "player";
        private static char[] images = new char[] { '\u263a', '\u263b'};

        // Methods
        // --- Constructors
        public Player(Vector2D position, int playerCount) : base(position)
        {
            this.body = images[playerCount % 2];
        }


        // --- Overrided Methods
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "wall" || otherCollisionGroupString == "box"
                || otherCollisionGroupString == "player";
        }

        public override string GetCollisionGroupString()
        {
            return Player.CollisionGroupString;
        }

        //public override void RespondToCollision(CollisionData collisionData)
        //{
            
        //}
    }
}
