using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class Municipality
    {
        public Municipality()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Display(Name = "Община")]
        public string Name { get; set; }
    }
}