using MB.ApplicationContract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(CreateComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _context.Comments.Add(comment);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
