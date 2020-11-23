using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Patient { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public bool Completed { get; set; }

        public bool AllowMultiCompletion { get; set; }

    }
}