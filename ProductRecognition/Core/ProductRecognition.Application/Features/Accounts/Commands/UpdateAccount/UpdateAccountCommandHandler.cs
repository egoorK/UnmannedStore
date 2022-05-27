using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Application.Features.Accounts.Commands.UpdateAccount
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

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken) // Реализует обработку запроса от Контроллера, переданного через Медиатор 
        {
            var accountEntity = _mapper.Map<Account>(request);
            await _accountRepository.UpdateAsync(accountEntity);

            return Unit.Value;
        }
    }
}
