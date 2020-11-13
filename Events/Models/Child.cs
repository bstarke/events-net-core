using System;
using System.Collections.Generic;

namespace Events.Models
{
    public partial class Child
    {
        public long Id { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Name { get; set; }
        public long? GuardianId { get; set; }

        public virtual Guardian Guardian { get; set; }
    }
}
