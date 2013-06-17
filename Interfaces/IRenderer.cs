using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public interface IRenderer
    {
        void EnqueueForRender(IRenderable obj);

        void RenderAll();

        void ClearQueue();
        void DisplayLevel(int level);

        void DisplayTimer(int time);
        void DisplayShowControls();
        void DisplayControls();
        void Clear();
    }
}
