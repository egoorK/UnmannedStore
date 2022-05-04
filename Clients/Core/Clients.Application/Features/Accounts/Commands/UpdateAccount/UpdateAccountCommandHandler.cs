using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Clients.Domain.Entities;
using Clients.Application.Contracts.Persistence;

namespace Clients.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            //var accountToUpdate = await _accountRepository.GetAccountByIdAsync(request.Account_ID);   // Нужно осуществлять поиск в бд здесь или в репозитории?
            //  _mapper.Map(request, accountToUpdate, typeof(UpdateAccountCommand), typeof(Account));
            
            var accountToUpdate = _mapper.Map<Account>(request);
            await _accountRepository.UpdateAsync(accountToUpdate);

            return Unit.Value;
        }

    }
}
