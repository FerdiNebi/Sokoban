using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Keyboard : IUserInterface
    {
        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnResetPressed;

        public event EventHandler OnShowControlsPressed;

        public void ProcessInput()
        {
            Console.SetCursorPosition(0, 0);
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new PlayerArgs(0));
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new PlayerArgs(0));
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new PlayerArgs(0));
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new PlayerArgs(0));
                    }
                }

                //Player  2
                if (keyInfo.Key.Equals(ConsoleKey.A))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new PlayerArgs(1));
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.D))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new PlayerArgs(1));
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.W))
                {
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new PlayerArgs(1));
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.S))
                {
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new PlayerArgs(1));
                    }
                }

                //Reset button

                if (keyInfo.Key.Equals(ConsoleKey.R))
                {
                    if (this.OnResetPressed != null)
                    {
                        this.OnResetPressed(this, new EventArgs());
                    }
                }

                //Show controls button
                if (keyInfo.Key.Equals(ConsoleKey.C))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnShowControlsPressed(this, new PlayerArgs(0));
                    }
                }
            }
            //throw new NotImplementedException();
        }
    }
}
