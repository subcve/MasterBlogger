using System;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }

        protected Comment()
        {
            
        }
        public Comment(string name, string email, string message, long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate =DateTime.Now;
            Status = Statuses.New;
        }

        public void Confirm(long id)
        {
            Status = Statuses.Confirm;
        }
        public void Cancel(long id)
        {
            Status = Statuses.Canceled;
        }
    }
}
