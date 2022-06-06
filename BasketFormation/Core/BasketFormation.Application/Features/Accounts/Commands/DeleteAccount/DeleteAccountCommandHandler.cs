using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public DeleteAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken) // Реализует обработку запроса от Контроллера, переданного через Медиатор 
        {
            var accountEntity = _mapper.Map<Account>(request);
            await _accountRepository.DeleteAsync(accountEntity);

            return Unit.Value;
        }
    }
}
