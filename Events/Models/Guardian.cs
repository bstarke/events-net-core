using System;
using System.Collections.Generic;

namespace Events.Models
{
    public partial class Guardian
    {
        public Guardian()
        {
            Child = new HashSet<Child>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Child> Child { get; set; }
    }
}
