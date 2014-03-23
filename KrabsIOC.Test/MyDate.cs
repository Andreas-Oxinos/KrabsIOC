using System;

namespace KrabsIOC.Test
{
    public class MyDate : IDate
    {
        public string Date()
        {
            return DateTime.Now.ToString();
        }
    }
}