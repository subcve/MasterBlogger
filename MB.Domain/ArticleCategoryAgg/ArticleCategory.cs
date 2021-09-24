using System;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            CheckRecordIsNullOrEmpty(title);
            validatorService.CheckThatThisRecordAlreadyExist(title);
            Title = title;
            IsRemoved = false;
            CreationDate = DateTime.Now;

        }
        protected ArticleCategory()
        {
                
        }

        public void Rename(string title)
        {
            CheckRecordIsNullOrEmpty(title);
            Title = title;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }

        public void CheckRecordIsNullOrEmpty(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        } 
    }
}
