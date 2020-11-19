using System;
using System.ComponentModel.DataAnnotations;

namespace eDoc.Data.Models
{
    public class Contact
    {
        public Contact()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}