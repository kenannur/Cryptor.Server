using System;
using System.Threading.Tasks;
using CryptorService.Contexts;
using CryptorService.CQRS.Queries;
using CryptorService.Entities;
using CryptorService.HttpClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptorService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly CryptoDbContext _dbContext;
        private readonly IParibuHttpClient _paribuHttpClient;
        private readonly IMediator _mediator;

        public TestController(CryptoDbContext dbContext, IParibuHttpClient paribuHttpClient, IMediator mediator)
        {
            _dbContext = dbContext;
            _paribuHttpClient = paribuHttpClient;
            _mediator = mediator;
        }

        [HttpPost, ActionName("SaveToDb")]
        public async Task<IActionResult> SaveToDbAsync()
        {
            _dbContext.Tests.Add(new Test
            {
                Key = "asd",
                DecimalValue = 396927.78627525m
            });
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet, ActionName("FetchTickerResult")]
        public async Task<IActionResult> FetchTickerResultAsync()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet, ActionName("FetchMarketHistory")]
        public async Task<IActionResult> FetchMarketHistoryAsync()
        {
            await _mediator.Send(new FetchMarketHistoryQueryRequest());
            return Ok();
        }
    }
}
