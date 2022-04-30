﻿using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Clients.Application.Features.Accounts.Queries.GetAccounts;


namespace Clients.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountsVm>
    {
        private readonly IMapper _mapper;

        public GetAccountQueryHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AccountsVm> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountById(request.Account_ID);
            return _mapper.Map<AccountsVm>(account);
        }
    }
}