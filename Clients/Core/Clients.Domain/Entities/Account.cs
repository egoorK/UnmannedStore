using System;
using System.Collections.Generic;

namespace Clients.Domain.Entities
{
    class Account
    {
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
        public List<UserDevice> UserDevices { get; set; } = new List<UserDevice>(); // связь многие ко многим
    }
}
