using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public interface ICollidable
    {
       bool CanCollideWith(string objectType);

       string GetCollisionGroupString();
    }
}
