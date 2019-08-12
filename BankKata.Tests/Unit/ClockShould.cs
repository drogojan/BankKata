using System;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class ClockShould
    {
        [Test]
        public void Return_Todays_Date_In_dd_MM_yyyy_Format()
        {
            Clock clock = new TestableClock();
            string date = clock.TodayAsString();
            Assert.That(date, Is.EqualTo("30/06/2019"));
        }

        private class TestableClock : Clock
        {
            protected override DateTime Today()
            {
                return new DateTime(2019, 6, 30);    
            }
        }
    }
}