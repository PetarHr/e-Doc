using System;

namespace eDoc.Data.Models
{
    public class MedicalCenter
    {
        public MedicalCenter()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}