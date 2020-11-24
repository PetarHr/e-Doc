using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name ="Работодател")]
        public string Name { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<ApplicationUser> Employees { get; set; }
    }
}