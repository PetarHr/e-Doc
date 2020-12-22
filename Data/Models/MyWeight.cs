using System;
using System.ComponentModel.DataAnnotations;
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
        [Range(0, double.MaxValue, ErrorMessage = "Моля, въведете валидна стойност за тегло.")]
        public double Value { get; set; }
        public DateTime RecordDate { get; set; }
        
        [ForeignKey(nameof(User))]
        public string UserId  { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
