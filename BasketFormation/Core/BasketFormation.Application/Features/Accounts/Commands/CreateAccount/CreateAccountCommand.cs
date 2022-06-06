using System;
using MediatR;

namespace BasketFormation.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Unit>
    {
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
    }
}
