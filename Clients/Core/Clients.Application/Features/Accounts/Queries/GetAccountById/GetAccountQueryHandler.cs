using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Clients.Application.Features.Accounts.Queries.GetAccounts;
using Clients.Application.Contracts.Persistence;


namespace Clients.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountsVm>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public GetAccountQueryHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AccountsVm> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByIdAsync(request.Account_ID);
            return _mapper.Map<AccountsVm>(account);
        }
    }
}
