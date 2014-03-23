using System;

namespace KrabsIOC.Test
{
    class DailyPresenter
    {
        private IDate myDate;

        private readonly IClock myclock;

        public DailyPresenter(IDate date, IClock clock)
        {
            myDate = date;
            myclock = clock;
        }

        internal void Start()
        {
            Console.Write("Today is: {0}", myDate.Date());
            Console.Write("The time is: {0}", myclock.GetTime());   
        }
    }
}