using System;

namespace BankKata
{
    public class Clock : IClock
    {
        public string TodayAsString()
        {
            var today = Today();
            return today.ToString("dd/MM/yyyy");
        }

        protected virtual DateTime Today()
        {
            return DateTime.Now;
        }
    }
}