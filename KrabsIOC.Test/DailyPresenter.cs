using System;

namespace KrabsIOC.Test
{
    class DailyPresenter
    {
        private IDate myDate;

        public DailyPresenter(IDate date)
        {
            myDate = date;
        }

        internal void Start()
        {
            Console.Write("Today is: {0}", myDate.Date());
        }
    }
}