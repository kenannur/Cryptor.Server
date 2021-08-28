using System;
using System.Collections.Generic;

namespace CryptorService.Models
{
    public class ParibuMarketDetailResponse
    {
        //public dynamic OrderBook { get; set; }

        public List<MarketMatch> MarketMatches { get; set; }
    }

    public class MarketMatch
    {
        public long Timestamp { get; set; }

        public string Amount { get; set; }

        public string Price { get; set; }

        // "buy" or "sell"
        public string Trade { get; set; }
    }

    public class MarketHistory
    {
        public DateTime DateTime { get; set; }

        public decimal Amount { get; set; }

        public decimal Price { get; set; }

        // "BUY" or "SELL"
        public string Trade { get; set; }
    }
}
