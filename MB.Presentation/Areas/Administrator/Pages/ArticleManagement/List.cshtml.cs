using System.Collections.Generic;
using System.Xml.Serialization;
using MB.ApplicationContract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;


        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
            return
            RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostRestore(long id)
        {
            _articleApplication.Restore(id);
            return
            RedirectToPage("./list");
        }
    }
}
