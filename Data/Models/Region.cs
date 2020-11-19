using System;
using System.ComponentModel.DataAnnotations;

namespace eDoc.Data.Models
{
    public class Region
    {
        public Region()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        [Display(Name = "Област")]
        public string Name { get; set; }
    }
}