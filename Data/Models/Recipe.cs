using System;

namespace eDoc.Data.Models
{
    public class Recipe
    {
        public string Id { get; set; }
        public ApplicationUser Patient { get; set; }

        public Doctor Doctor { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;
    }
}