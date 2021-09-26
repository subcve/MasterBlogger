using System.Collections.Generic;
using System.Net.Mime;

namespace MB.ApplicationContract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
    }
}
