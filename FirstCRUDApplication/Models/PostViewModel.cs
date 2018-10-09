namespace Coffee.Models
{
    public class PostViewModel
    {
        public long post_id { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public int likes { get; set; }

        public bool is_liked { get; set; }
    }
}
