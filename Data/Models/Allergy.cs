using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class Allergy
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime DiscoveredOn { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}