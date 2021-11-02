using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
namespace Tanks.Code
{
    public delegate void StartTimer(object o);

    public class TimeManager
    {
        public delegate void ElapsedtTimer(string o);
        public event ElapsedtTimer Elapsed;

        private int timer = 0;
        public bool IsElapsed { get; set; }
        public int Timer { get => timer; set => timer = value; }

        System.Threading.Timer _timer;
        int _timerValue, _period;
        public TimeManager(int timerValue, int period)
        {
            this._timerValue = timerValue;
            this._period = period;
        }

        public TimeManager(int timerValue)
        {
            this._timerValue = timerValue;

        }
        public void StartTimerWithOutDispose(object o)
        {
            TimerCallback tm = new TimerCallback(WaitWithOutDispose);
            _timer = new System.Threading.Timer(tm, 0, 0, _period);
        }
        //For AI Shooting
        public void WaitWithOutDispose(object o)
        {
            if (timer >= _timerValue)
            {
                IsElapsed = true;
                timer = 0;
                Elapsed(o.ToString());

                return;
            }
            else
            {
                timer += 1;
                IsElapsed = false;
            }
        }
    }



}
