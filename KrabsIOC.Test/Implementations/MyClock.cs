using System;

namespace KrabsIOC.Test
{
    public class MyClock : IClock
    {
        public string GetTime()
        {
            return string.Format("Time is: {0}", DateTime.Now.TimeOfDay);
        }
    }
}