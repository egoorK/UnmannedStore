using System;
using Clients.Application.Contracts.Persistence;
using Clients.Persistence.ContextsDB;
using Clients.Domain.Entities; 
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clients.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly AccountContext _dbContext;

        public AccountRepository(AccountContext dbContext) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> AddAsync(Account entity)
        {
            _dbContext.Accounts.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Account_ID;
        }

        public async Task UpdateAsync(Account entity) // ???
        {
            var accountToUpdate = await _dbContext.Accounts.FindAsync(entity.Account_ID); // Проверка на наличие | new object[] { entity.Account_ID }

            // Добавить обработку исключений
            if (accountToUpdate == null)
            {
                //  throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            else
            {
                accountToUpdate.Account_ID = entity.Account_ID;
                accountToUpdate.Username = entity.Username;
                accountToUpdate.Email = entity.Email;
                accountToUpdate.Date_of_Birth = entity.Date_of_Birth;
                accountToUpdate.Phone_number = entity.Phone_number;
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
        public async Task<Account> GetAccountByIdAsync(Guid entityId)
        {
            return await _dbContext.Accounts.FindAsync(entityId);
        }
        
        public async Task<IReadOnlyList<Account>> GetAccountsAllAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

    }
}
