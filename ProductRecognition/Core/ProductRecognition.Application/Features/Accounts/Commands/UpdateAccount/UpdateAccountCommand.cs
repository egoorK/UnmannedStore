using System;
using MediatR;

namespace ProductRecognition.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<Unit>
    {
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
    }
}
