using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Clients.Domain.Entities;

namespace Clients.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToDelete = await _accountRepository.GetByIdAsync(request.Account_ID);

            /* Добавить обработку исключений
            if(accountToUpdate == null)
            {
                throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            */

            await _accountRepository.DeleteAsync(accountToDelete);

            return Unit.Value;
        }
    }
}
