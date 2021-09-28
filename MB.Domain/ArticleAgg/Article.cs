using System;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        
        protected Article()
        {
            
        }
        public Article(string title, string shortDescription, string content, string image, long articleCategoryId,IArticleValidatorServices validatorServices)
        {
            CheckRecordNullOrEmpty(title);
            validatorServices.CheckThatThisRecordAlreadyExist(title);
            Title = title;
            CheckRecordNullOrEmpty(shortDescription);
            ShortDescription = shortDescription;
            Content = content;
            CheckRecordNullOrEmpty(image);
            Image = image;
            CheckRecordIsNotZero(articleCategoryId);
            ArticleCategoryId = articleCategoryId;
            IsRemoved = false;
            CreationDate = DateTime.Now;
        }

        public void Edit(string title, string shortDescription, string content, string image, long articleCategoryId,IArticleValidatorServices validatorServices)
        {
            CheckRecordNullOrEmpty(title);
            validatorServices.CheckThatThisRecordAlreadyExist(title);
            Title = title;
            CheckRecordNullOrEmpty(shortDescription);
            ShortDescription = shortDescription;
            Content = content;
            CheckRecordNullOrEmpty(image);
            Image = image;
            CheckRecordIsNotZero(articleCategoryId);
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

        private static void CheckRecordNullOrEmpty(string variable)
        {
            if (string.IsNullOrWhiteSpace(variable))
                throw new ArgumentNullException();
        }
        private static void CheckRecordIsNotZero(long variable)
        {
            if (variable == 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
