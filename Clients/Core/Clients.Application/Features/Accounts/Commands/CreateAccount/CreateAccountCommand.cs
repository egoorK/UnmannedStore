using System;
using System.Collections.Generic;
using System.Text;

namespace Clients.Application.Features.Accounts.Commands.CreateAccount
{
    class CreateAccountCommand
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
    }
}
