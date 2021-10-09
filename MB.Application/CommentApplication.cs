using System.Collections.Generic;
using MB.ApplicationContract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(CreateComment command)
        {
            _commentRepository.CreateAndSave(command);
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Confirm(id);
            _commentRepository.Save();
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Cancel(id);
            _commentRepository.Save();
        }
    }
}
