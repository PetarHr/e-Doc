using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace eDoc.Data.Models
{
    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public Municipality Municipality { get; set; }
        [Display(Name = "Град")]
        public string City { get; set; }
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Display(Name = "№")]
        public int StreetNumber { get; set; }
        [Display(Name = "Етаж")]
        public int Floor { get; set; }
        [Display(Name = "Апартамент")]
        public string Apartment { get; set; }
        [Display(Name = "Вход")]
        public string Entrance { get; set; }
        [Display(Name = "Коментар")]
        public string Comment { get; set; }
    }
}