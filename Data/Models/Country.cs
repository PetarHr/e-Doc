using System;
using System.ComponentModel.DataAnnotations;

namespace eDoc.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        [Display(Name = "Държава")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
    }
}