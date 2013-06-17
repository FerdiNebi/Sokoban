using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public interface IRenderable
    {
        char GetImage();
        Vector2D GetPosition();
    }
}
