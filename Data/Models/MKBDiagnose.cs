using System;

namespace eDoc.Data.Models
{
    public class MKBDiagnose
    {
        public MKBDiagnose()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}