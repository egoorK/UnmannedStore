﻿using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Clients.Domain.Entities;
using Clients.Application.Contracts.Persistence;

namespace Clients.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>  // Типы входных и выходных данных
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken) // Реализует обработку запроса от Контроллера, переданного через Медиатор 
        {
            var accountEntity = _mapper.Map<Account>(request);
            var newAccountId = await _accountRepository.AddAsync(accountEntity);

            return newAccountId; // newAccount.Account_ID
        }

        // CancellationToken cancellationToken - для безаварийной отмены задачи в случае сбоя
    }
}
