using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BasketFormation.Domain.Entities;
using BasketFormation.Persitence.ContextsDB;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Persitence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly RepositoryContext _dbContext;

        public AccountRepository(RepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Account entity)
        {
            _dbContext.Accounts.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account entity)
        {
            var accountToUpdate = await _dbContext.Accounts.FindAsync(entity.Account_ID);

            // Добавить обработку исключений
            if (accountToUpdate == null)
            {
                //  throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            else
            {
                accountToUpdate.Account_ID = entity.Account_ID;
                accountToUpdate.Username = entity.Username;
                
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Account entity)
        {
            var accountToDelete = await _dbContext.Accounts.FindAsync(new object[] { entity.Account_ID });

            //if (entitY == null)
            //{
            //    throw new NotFoundException(nameof(Account), entity.Account_ID);
            //}

            _dbContext.Accounts.Remove(accountToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
