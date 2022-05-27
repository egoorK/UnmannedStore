using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Persistence.Configuration;
using ProductRecognition.Persistence.ContextsDB.Contracts;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IRepositoryContext _dbContext;

        public AccountRepository(IRepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Account entity)
        {
            var entityToDatabase = new AccountConfiguration()
            {
                Account_ID = entity.Account_ID,
                Username = entity.Username
            };

            await _dbContext.Accounts.InsertOneAsync(entityToDatabase);
        }

        public async Task UpdateAsync(Account entity)
        {
            var update = Builders<AccountConfiguration>.Update
                    .Set(c => c.Account_ID, entity.Account_ID)
                    .Set(c => c.Username, entity.Username);

            await _dbContext.Accounts.UpdateOneAsync(filter: g => g.Account_ID == entity.Account_ID, update);
        }

        public async Task DeleteAsync(Guid entityId)
        {
            FilterDefinition<AccountConfiguration> filter = Builders<AccountConfiguration>.Filter.Eq(p => p.Account_ID, entityId);

            await _dbContext.Accounts.DeleteOneAsync(filter);
        }
    }
}
