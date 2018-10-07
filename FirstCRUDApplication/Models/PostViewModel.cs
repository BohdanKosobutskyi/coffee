namespace Coffee.Models
{
    public class PostViewModel
    {
        public int post_id { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public int like_count { get; set; }

        public bool is_liked { get; set; }
    }
}
