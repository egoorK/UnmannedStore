using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Clients.Domain.Entities;

namespace Clients.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToUpdate = await _accountRepository.GetByIdAsync(request.Account_ID);

            /* Добавить обработку исключений
            if(accountToUpdate == null)
            {
                throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            */

            _mapper.Map(request, accountToUpdate, typeof(UpdateAccountCommand), typeof(Account));

            await _accountRepository.UpdateAsync(accountToUpdate);

            return Unit.Value;
        }

    }
}
