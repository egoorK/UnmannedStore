using System;
using System.Collections.Generic;
using System.Text;

namespace Clients.Application.DTOForEvents
{
    public class AccountDeletedEvent
    {
        public string Event_Type { get; set; } = "deleted";
        public Guid Account_ID { get; set; }
    }
}
