namespace MB.ApplicationContract.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }
}
