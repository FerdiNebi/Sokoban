using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public abstract class GameObject : ICollidable, IRenderable
    {
        public const string CollisionGroupString = "object";
        protected Vector2D position;
        protected char body;
        public bool IsVisible { get; set; }

        protected GameObject(Vector2D position)
        {
            this.position = position;       
            this.body = ' ';
            this.IsVisible = true;
        }
        
        public virtual char GetImage()
        {
            return this.body;
        }

        //Till this moment when this method is called it will always return true.
        public virtual bool CanCollideWith(string objectType)
        {
            return true;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;

        }
        
        public virtual Vector2D GetPosition()
        {
            return this.position;
        }

       
    }
}
