using System.Collections.Generic;
using MB.ApplicationContract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetList();
        }

        public RedirectToPageResult OnPostAccept(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostReject(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }
    }
}
