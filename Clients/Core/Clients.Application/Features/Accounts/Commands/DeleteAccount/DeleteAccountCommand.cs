using MediatR;
using System;

namespace Clients.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid Account_ID { get; set; }
    }
}
