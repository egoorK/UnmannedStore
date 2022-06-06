using System;

namespace BasketFormation.Infrastructure.DTOForEvents
{
    public class AccountCommandEvent
    {
        public string Event_Type { get; set; }
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Phone_number { get; set; }
    }
}
