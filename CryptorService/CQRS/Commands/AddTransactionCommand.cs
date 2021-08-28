using System.Threading;
using System.Threading.Tasks;
using CryptorService.Contexts;
using CryptorService.Entities;
using MediatR;

namespace CryptorService.CQRS.Commands
{
    public class AddTransactionCommandRequest : IRequest
    {
        public Transaction Transaction { get; private set; }

        public AddTransactionCommandRequest(Transaction transaction)
        {
            Transaction = transaction;
        }
    }

    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommandRequest>
    {
        private readonly CryptoDbContext _dbContext;

        public AddTransactionCommandHandler(CryptoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            _dbContext.Transactions.Add(request.Transaction);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
