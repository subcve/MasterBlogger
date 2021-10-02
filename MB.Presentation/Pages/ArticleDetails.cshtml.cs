using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryViewModel Article { get; set; }
        public ArticleQueryViewModel LastArticle { get; set; }
        private readonly IArticleQuery _articleQuery;

        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.GetArticle(id);
            LastArticle = _articleQuery.GetLastArticle();
        }
    }
}
