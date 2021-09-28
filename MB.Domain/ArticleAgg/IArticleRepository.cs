using System.Collections.Generic;
using MB.ApplicationContract.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article entity);
        Article Get(long id);
        void Save();
    }
}
