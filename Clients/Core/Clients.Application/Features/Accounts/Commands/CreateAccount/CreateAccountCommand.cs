using System;
using MediatR;
using System.Collections.Generic;

namespace Clients.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>  // Запрос с ответом GUID
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
    }
}
