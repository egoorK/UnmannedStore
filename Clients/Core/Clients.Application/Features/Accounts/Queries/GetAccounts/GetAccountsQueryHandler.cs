using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Clients.Application.Contracts.Persistence;

namespace Clients.Application.Features.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<AccountsVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public GetAccountsQueryHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<List<AccountsVm>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAccountsAllAsync();
            return _mapper.Map<List<AccountsVm>>(accounts);
        }
    }
}
