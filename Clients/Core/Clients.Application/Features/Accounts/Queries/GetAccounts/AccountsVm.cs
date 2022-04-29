﻿using System;

namespace Clients.Application.Features.Accounts.Queries.GetAccounts
{
    public class AccountsVm
    {
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
    }
}
