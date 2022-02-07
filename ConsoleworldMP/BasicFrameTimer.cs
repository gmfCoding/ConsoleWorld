using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class BasicFrameTimer
    {
        Stopwatch time = new Stopwatch();
        bool loop = true;
        double dt;

        int wait;

        public BasicFrameTimer(int wait = 1)
        {
            this.wait = wait;
        }

        public bool Loop(out double dt)
        {
            dt = time.Elapsed.TotalSeconds;
            Stop();
            System.Threading.Thread.Sleep(wait);
            Restart();
            return loop;
        }

        public void Stop() => time.Stop();
        public void Start() => time.Start();
        public void Restart() => time.Restart();


        public void Exit()
        {
            loop = false;
        }
    }
}
