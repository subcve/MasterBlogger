using System.Collections.Generic;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryViewModel> Article { get; set; }
        private readonly IArticleQuery _articleQuery;
        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet()
        {
            Article = _articleQuery.GetArticles();
        }
    }
}
