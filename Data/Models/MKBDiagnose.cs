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
        public int Code { get; set; }
        public string Description { get; set; }
    }
}