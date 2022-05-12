using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Clients.Domain.Entities;
using Clients.Application.DTOForEvents;
using Clients.Application.Contracts.Persistence;
using Clients.Application.Contracts.Infrastructure;

namespace Clients.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountPublisher _accountPublisher;

        public UpdateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository, IAccountPublisher accountPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountPublisher = accountPublisher ?? throw new ArgumentNullException(nameof(accountPublisher));
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            //var accountToUpdate = await _accountRepository.GetAccountByIdAsync(request.Account_ID);
            //  _mapper.Map(request, accountToUpdate, typeof(UpdateAccountCommand), typeof(Account));
            
            var accountToUpdate = _mapper.Map<Account>(request);
            await _accountRepository.UpdateAsync(accountToUpdate);

            var accountEventEntity = _mapper.Map<AccountUpdatedEvent>(request);
            await _accountPublisher.SendMessageAsync(accountEventEntity);

            return Unit.Value;
        }

    }
}
