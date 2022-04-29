using MediatR;
using System;
using Clients.Application.Features.Accounts.Queries.GetAccounts;

namespace Clients.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountQuery : IRequest<AccountsVm>
    {
        public Guid Account_ID { get; set; }

        public GetAccountQuery(Guid Id)
        {
            if(Id != null)
                Account_ID = Id;
            else
                throw new ArgumentNullException(nameof(Id));
        }
    }
}
