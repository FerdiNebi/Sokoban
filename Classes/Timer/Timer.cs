using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NotJustSokoban.Classes.Timer;


public class Timer
{
    private int time;
    private int initialTime;
    private System.Threading.ReaderWriterLock locker = new ReaderWriterLock(); //Lock used for synchronization
 
    public Timer(int time)
    {
        this.initialTime = time;
        this.time = time;
    }

    public int Time { get { return this.time; } }

    //Reset the timer to its initial time;
    public void Reset()
    {
        try
        {
            //lock the lock
            locker.AcquireWriterLock(10000);

            this.time = initialTime;

            //unlock the lock
            locker.ReleaseLock();
        }
        catch (System.ApplicationException ex)
        {

        }
    }

    //Endless timer 
    public void Start()
    {
        while (true)
        {
            try
            {
                //lock the lock
                locker.AcquireWriterLock(6000);

                this.time--;
                if (this.time < 0)
                {
                    this.time = 0;
                }
                //unlock the lock
                locker.ReleaseLock();
                Thread.Sleep(1000);
            }
            catch (System.ApplicationException ex)
            {
            }
        }

    }

    public int InitialTime
    {
        get { return this.initialTime; }
        set { this.initialTime = value; }
    }
    
}

