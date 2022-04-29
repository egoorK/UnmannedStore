using System;
using System.Collections.Generic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clients.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = _mapper.Map<Account>(request);
            var newAccount = await _accountRepository.AddAsync(accountEntity);
        }
    }
}
