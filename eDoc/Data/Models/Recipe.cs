namespace eDoc.Data.Models
{
    public class Recipe
    {
        public string Id { get; set; }
        public User Patient { get; set; }

        public User Doctor { get; set; }
    }
}