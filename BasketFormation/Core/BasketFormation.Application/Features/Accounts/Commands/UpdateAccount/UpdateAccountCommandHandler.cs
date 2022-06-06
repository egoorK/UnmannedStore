using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
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
            var accountEntity = _mapper.Map<Account>(request);
            await _accountRepository.UpdateAsync(accountEntity);

            return Unit.Value;
        }
    }
}
