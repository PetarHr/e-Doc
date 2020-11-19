using System;

namespace eDoc.Data.Models
{
    public class IssuedDoc
    {
        public IssuedDoc()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}