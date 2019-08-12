namespace BankKata
{
    public class Transaction
    {

        private readonly string date;
        private readonly int amount;

        protected bool Equals(Transaction other)
        {
            return string.Equals(date, other.date) && amount == other.amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((date != null ? date.GetHashCode() : 0) * 397) ^ amount;
            }
        }

        public Transaction(string date, int amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public string Date => date;

        public int Amount => amount;
    }
}