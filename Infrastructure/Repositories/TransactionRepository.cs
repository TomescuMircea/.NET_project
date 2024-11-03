using Domain.Common;
using Domain.Repositories;


using System.Transactions;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<Result<Guid>> AddAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}