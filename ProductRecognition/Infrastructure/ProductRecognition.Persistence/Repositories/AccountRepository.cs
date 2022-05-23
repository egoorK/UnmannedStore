using System;
using System.Collections.Generic;
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
    }
}
