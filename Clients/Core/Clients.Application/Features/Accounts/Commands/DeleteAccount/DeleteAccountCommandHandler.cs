using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Clients.Domain.Entities;
using Clients.Application.DTOForEvents;
using Clients.Application.Contracts.Persistence;
using Clients.Application.Contracts.Infrastructure;

namespace Clients.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountPublisher _accountPublisher;

        public DeleteAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository, IAccountPublisher accountPublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountPublisher = accountPublisher ?? throw new ArgumentNullException(nameof(accountPublisher));
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var req = _mapper.Map<Account>(request);
            var accountToDelete = await _accountRepository.GetAccountByIdAsync(req.Account_ID);

            /* Добавить обработку исключений
            if(accountToUpdate == null)
            {
                throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            */

            await _accountRepository.DeleteAsync(accountToDelete);

            var accountEventEntity = _mapper.Map<AccountDeletedEvent>(request);
            await _accountPublisher.SendMessageAsync(accountEventEntity);

            return Unit.Value;
        }
    }
}
