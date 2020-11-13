using System;
using System.Collections.Generic;

namespace Events.Models
{
    public partial class Event
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool RegistrationOpen { get; set; }
    }
}
