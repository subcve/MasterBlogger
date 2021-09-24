using System.Collections.Generic;

namespace MB.ApplicationContract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory Get(long id);
        void Remove(long id);
        void Restore(long id);
    }
}
