using System;
using System.Threading;
using System.Threading.Tasks;
using CryptorService.Contexts;
using CryptorService.Entities;
using CryptorService.HttpClients;
using CryptorService.Models;
using MediatR;

namespace CryptorService.CQRS.Commands
{
    public class AddTickerDataCommandRequest : IRequest
    { }


    public class AddTickerDataCommandHandler : IRequestHandler<AddTickerDataCommandRequest>
    {
        private readonly IParibuHttpClient _paribuHttpClient;
        private readonly CryptoDbContext _dbContext;

        public AddTickerDataCommandHandler(IParibuHttpClient paribuHttpClient, CryptoDbContext dbContext)
        {
            _paribuHttpClient = paribuHttpClient;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddTickerDataCommandRequest request, CancellationToken cancellationToken)
        {
            var tickerResponse = await _paribuHttpClient.FetchAsync<ParibuTickerResponse>("ticker", cancellationToken);

            var tickerData = CreateTickerData(tickerResponse);
            _dbContext.TickerDatas.Add(tickerData);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private static TickerData CreateTickerData(ParibuTickerResponse tickerResponse)
        {
            var ccys = tickerResponse.BtcTlTickerResult.Pair.Split('-');
            var tickerData = new TickerData
            {
                CreatedDate = DateTime.Now,
                MainCcy = ccys[0].ToUpper(),
                CounterCcy = ccys[1].ToUpper(),
                Bid = tickerResponse.BtcTlTickerResult.Bid,
                Ask = tickerResponse.BtcTlTickerResult.Ask
            };

            return tickerData;
        }
    }
}
