using System.Collections.Generic;
using MB.ApplicationContract.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(CreateComment command);
        List<CommentViewModel> GetList();
        Comment GetBy(long id);
        void Save();
    }
}
