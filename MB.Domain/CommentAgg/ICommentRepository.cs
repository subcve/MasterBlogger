using MB.ApplicationContract.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(CreateComment command);
    }
}
