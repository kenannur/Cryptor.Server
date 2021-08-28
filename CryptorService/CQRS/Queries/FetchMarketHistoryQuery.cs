using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptorService.HttpClients;
using CryptorService.Models;
using MediatR;

namespace CryptorService.CQRS.Queries
{
    public class FetchMarketHistoryQueryRequest : IRequest
    { }

    public class FetchMarketHistoryQueryHandler : IRequestHandler<FetchMarketHistoryQueryRequest>
    {
        private readonly IParibuHttpClient _paribuHttpClient;

        public FetchMarketHistoryQueryHandler(IParibuHttpClient paribuHttpClient)
        {
            _paribuHttpClient = paribuHttpClient;
        }

        public async Task<Unit> Handle(FetchMarketHistoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _paribuHttpClient.FetchAsync<ParibuMarketDetailResponse>("markets/btc-tl");
            var marketHistoryList = new List<MarketHistory>();
            foreach (var marketMatch in response.MarketMatches)
            {
                var marketHistory = new MarketHistory
                {
                    DateTime = DateTimeOffset.FromUnixTimeSeconds(marketMatch.Timestamp).DateTime,
                    Amount = decimal.Parse(marketMatch.Amount, NumberStyles.Float),
                    Price = decimal.Parse(marketMatch.Price, NumberStyles.Float),
                    Trade = marketMatch.Trade.ToUpper()
                };
                marketHistoryList.Add(marketHistory);
            }

            var buys = marketHistoryList.Where(x => x.Trade == "BUY");
            var sells = marketHistoryList.Where(x => x.Trade == "SELL");

            var totalBuys = buys.Sum(x => x.Amount * x.Price);
            var totalSells = sells.Sum(x => x.Amount * x.Price);

            return Unit.Value;
        }
    }
}
