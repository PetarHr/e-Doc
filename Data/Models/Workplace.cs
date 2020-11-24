using System;
using System.Collections.Generic;

namespace eDoc.Data.Models
{
    public class Workplace
    {
        public Workplace()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<ApplicationUser>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<ApplicationUser> Employees { get; set; }
    }
}