using System;

namespace eDoc.Data.Models
{
    public class IssuedDocument
    {
        public IssuedDocument()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public DocumentType Type { get; set; }
        public string Description { get; set; }

    }
}