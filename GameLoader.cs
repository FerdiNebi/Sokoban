using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotJustSokoban
{
    class GameLoader
    {
        const int MapsOnFileCount = 7;
        const int HardcodedMapsCount = 7;
        const int InitialTimerLimit = 20;

        static void Main(string[] args)
        {
            //Get the intstance of Map. Map is singleton.
            Map currentMap = Map.Instance;

            //TODO : Implement use of Mappack class for loading maps.

            //Create a timer and start it in a new Thread
            Timer timer = new Timer(InitialTimerLimit);
            System.Threading.Thread theTimerThread = new System.Threading.Thread(new System.Threading.ThreadStart(timer.Start));
            theTimerThread.Start();

            for (int i = 1; i <= MapsOnFileCount + HardcodedMapsCount; i++)
            {
                try
                {
                    //Load map
                    if (i > HardcodedMapsCount)
                    {
                        currentMap.Load("Level" + (i - HardcodedMapsCount), "file/JSON");
                    }
                    else
                    {
                        currentMap.Load("TestLevel" + i, "hardcodedTest");
                    }
 
                    //Create Keyboard and ConsolreRenderer objects
                    IUserInterface keyboard = new Keyboard();
                    IRenderer renderer = new ConsoleRenderer(currentMap.Size.Y, currentMap.Size.X,currentMap.OriginTopLeft);

                    //Create the Engine object
                    Engine engine = new Engine(currentMap.ObjectDictionary, renderer, keyboard, i, timer, (currentMap.TimeLimit > 0));

                    //Subscribe for keyboard events
                    keyboard.OnRightPressed += (sender, eventInfo) =>
                    {
                        PlayerArgs playerInfo = (PlayerArgs)eventInfo;
                        int playerType = playerInfo.Player;
                        engine.MoveRight(playerType);
                    };

                    keyboard.OnLeftPressed += (sender, eventInfo) =>
                    {
                        PlayerArgs playerInfo = (PlayerArgs)eventInfo;
                        int playerType = playerInfo.Player;
                        engine.MoveLeft(playerType);
                    };
                    keyboard.OnUpPressed += (sender, eventInfo) =>
                    {
                        PlayerArgs playerInfo = (PlayerArgs)eventInfo;
                        int playerType = playerInfo.Player;
                        engine.MoveUp(playerType);
                    };
                    keyboard.OnDownPressed += (sender, eventInfo) =>
                    {
                        PlayerArgs playerInfo = (PlayerArgs)eventInfo;
                        int playerType = playerInfo.Player;
                        engine.MoveDown(playerType);
                    };

                    keyboard.OnResetPressed += (sender, eventInfo) =>
                        {
                            timer.Reset();
                            engine.Reset();
                        };
                    keyboard.OnShowControlsPressed += (sender, eventInfo) =>
                        {
                            renderer.DisplayControls();
                        };

                    timer.InitialTime = currentMap.TimeLimit;
                    //Reset the timer and Run the Engine
                    timer.Reset();
                    engine.Run();
                    System.Threading.Thread.Sleep(500);
                }
                catch (TimeoutException ex)
                {
                    ConsoleRenderer.DisplayTimeOut();
                    i--;
                }
            }
            ConsoleRenderer.PlayerWon();
            Environment.Exit(0);
        }

    }
}
