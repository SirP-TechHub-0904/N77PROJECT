namespace Domain.Models
{
    public class BlogCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public bool Publish { get; set; }

    }
}
