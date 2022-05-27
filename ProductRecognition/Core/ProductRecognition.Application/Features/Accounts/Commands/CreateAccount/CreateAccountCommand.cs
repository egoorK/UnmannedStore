using System;
using MediatR;

namespace ProductRecognition.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Unit>
    {
        public string Event_Type { get; set; } = "created";
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
    }
}
