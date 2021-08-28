using System;

namespace CryptorService.Entities
{
    public class MarketHistory : EntityBase
    {
        public string MainCcy { get; set; }

        public string CounterCcy { get; set; }

        // "BUY" or "SELL"
        public string Trade { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public decimal Price { get; set; }
    }
}
