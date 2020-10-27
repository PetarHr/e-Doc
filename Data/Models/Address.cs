using System.Threading;

namespace eDoc.Data.Models
{
    public class Address
    {
        public string Id { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public Municipality Municipality { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int Floor { get; set; }
        public string Apartment { get; set; }
        public string Entrance { get; set; }
        public string Comment { get; set; }
    }
}