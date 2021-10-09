using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.ApplicationContract.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

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

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(c => c.Article).Select(c => new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Message = c.Message,
                Statuses = c.Status,
                CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = c.Article.Title
            }).ToList();
        }

        public Comment GetBy(long id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
