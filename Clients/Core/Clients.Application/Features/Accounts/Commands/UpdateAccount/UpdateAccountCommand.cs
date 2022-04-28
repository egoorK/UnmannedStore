using System;
using System.Collections.Generic;
using System.Text;

namespace Clients.Application.Features.Accounts.Commands.UpdateAccount
{
    class UpdateAccountCommand
    {
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
    }
}
