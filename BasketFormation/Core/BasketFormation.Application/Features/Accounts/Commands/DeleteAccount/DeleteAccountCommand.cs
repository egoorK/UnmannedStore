using System;
using MediatR;

namespace BasketFormation.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<Unit>
    {
        public Guid Account_ID { get; set; }
    }
}
