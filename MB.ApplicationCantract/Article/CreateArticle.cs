namespace MB.ApplicationContract.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Image  { get; set; }
        public long ArticleCategoryId { get; set; }

    }
}