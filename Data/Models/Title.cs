namespace eDoc.Data.Models
{
    public enum Title
    {
        Господин = 0,
        Госпожица = 1, 
        Госпожа =2
    }
    public static class Extension
    {
        public static string ToString(this Title title)
        {
            return title switch
            {
                Title.Господин => "Г-н",
                Title.Госпожица => "Г-ца",
                Title.Госпожа => "Г-жа",
                _ => string.Empty,
            };
        }


    }
}
