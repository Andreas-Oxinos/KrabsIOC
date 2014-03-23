using System;
using System.Linq;
using KrabsIOC.Core;
using NUnit.Framework;

namespace KrabsIOC.Test
{
    [TestFixture]
    public class MainTest
    {
        [Test]
        public void Maintest1()
        {
            Injector injector = new Injector();
            injector.Bind<IDate, MyDate>();
            var letssee = injector.Resolve<DailyPresenter>();
            letssee.Start();
        }

        
    }
}
