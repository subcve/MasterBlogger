using System.Collections.Generic;

namespace MB.ApplicationContract.Comment
{
    public interface ICommentApplication
    {
        void Add(CreateComment command);
        List<CommentViewModel> GetList();
        void Confirm(long id);
        void Cancel(long id);
    }
}
