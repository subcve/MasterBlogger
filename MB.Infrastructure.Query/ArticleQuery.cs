using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryViewModel> GetArticles()
        {
            return _context.Articles.Where(c => c.IsRemoved == false)
                .Include(c=>c.Comments)
                .Include(c => c.ArticleCategory)
                .Select(c => new ArticleQueryViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ArticleCategory = c.ArticleCategory.Title,
                    CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                    LasTimeSinceCreation = DateToTitle(c.CreationDate),
                    Image = c.Image,
                    ShortDescription = c.ShortDescription,
                    CommentCount = c.Comments.Count(z => z.Status == Statuses.Confirm),
                }).ToList();
        }

        public ArticleQueryViewModel GetArticle(long id)
        {
            return _context.Articles.Where(c => c.IsRemoved == false)
                .Include(c => c.ArticleCategory)
                .Select(c => new ArticleQueryViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ArticleCategory = c.ArticleCategory.Title,
                    CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                    LasTimeSinceCreation = DateToTitle(c.CreationDate),
                    Image = c.Image,
                    ShortDescription = c.ShortDescription,
                    Content = c.Content,
                    CommentCount = c.Comments.Count(z => z.Status == Statuses.Confirm),
                    Comments = MapComments(c.Comments.Where(z => z.Status == Statuses.Confirm))
                }).FirstOrDefault(c => c.Id == id);
        }
        private static List<CommentQueryViewModel> MapComments(IEnumerable<Comment> comments)
        {
            var res = new List<CommentQueryViewModel>();
            foreach (var comment in comments)
            {
                res.Add(new CommentQueryViewModel
                {
                    Name = comment.Name,
                    Message = comment.Message,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return res;
        }
        public ArticleQueryViewModel GetLastArticle()
        {
            return _context.Articles.Where(c => c.IsRemoved == false)
                .Select(c => new ArticleQueryViewModel
                {
                    Id = c.Id
                }).OrderByDescending(c=>c.Id).FirstOrDefault();
        }

        public static string DateToTitle(DateTime dateTime)
        {

            TimeSpan ts = DateTime.Now - dateTime;
            int days = (int)ts.TotalDays;
            int hours = ((int)ts.TotalHours) % 24;
            int minutes = (int)ts.TotalMinutes % 60;

            DateTime value = DateTime.Now;
            if (days == 0 && hours == 0 && minutes < 60)
            {
                return "A Few Minutes Ago";
            }

            if (days == 0 && hours < 24 && minutes < 60)
            {
                if(hours == 1)
                    return (hours) + "Hour Ago";
                return (hours) + "Hours Ago";
            }

            if (days < 7 && hours < 24 && minutes < 60)
            {
                if (days == 1)
                    return (days) + "Day Ago";
                return (days) + "Days Ago";
            }

            if (days >= 7 && days <= 28)
            {
                if (days % 7 == 1)
                    return (days % 7) + "Days Ago";
                return (days % 7) + "Days Ago";
            }

            if (days > 28 && days < 365)
            {
                if(days % 29 == 1)
                    return (days % 29) + " Month ago";
                return (days % 29) + " Months ago";
            }

            if (days >= 365)
            {
                if(days % 365 == 1)
                    return (days % 365) + "Year Ago";
                return (days % 365) + "Years Ago";
            }

            return "";
        }
    }
}
