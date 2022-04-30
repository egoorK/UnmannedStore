using MediatR;
using System.Collections.Generic;

namespace Clients.Application.Features.Accounts.Queries.GetAccounts
{
    public class GetAccountsQuery : IRequest<List<AccountsVm>>
    {
    }
}
