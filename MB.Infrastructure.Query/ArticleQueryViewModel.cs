namespace MB.Infrastructure.Query
{
    public class ArticleQueryViewModel
    {
        public long  Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string CreationDate { get; set; }
        public string LasTimeSinceCreation { get; set; }
        public string Image { get; set; }
        public string ArticleCategory { get; set; }
        public string Content { get; set; }
    }
}
