using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class MyWeight
    {
        public MyWeight()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public double Value { get; set; }
        public DateTime RecordDate { get; set; }
        
        [ForeignKey(nameof(User))]
        public string UserId  { get; set; }
        public ApplicationUser User { get; set; }
    }
}
