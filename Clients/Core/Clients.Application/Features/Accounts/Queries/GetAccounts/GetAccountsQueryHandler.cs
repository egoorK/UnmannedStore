using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Clients.Application.Features.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<AccountsVm>>
    {
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public async Task<List<AccountsVm>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAccountsAll();
            return _mapper.Map<List<AccountsVm>>(accounts);
        }
    }
}
