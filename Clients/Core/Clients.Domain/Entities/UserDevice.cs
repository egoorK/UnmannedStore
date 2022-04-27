using System;
using System.Collections.Generic;

namespace Clients.Domain.Entities
{
    class UserDevice
    {
        public Guid Device_ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Screen_resolution_height { get; set; }
        public int Screen_resolution_width { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>(); // связь многие ко многим
    }
}
