using MB.Application;
using MB.ApplicationContract.Article;
using MB.ApplicationContract.ArticleCategory;
using MB.ApplicationContract.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            service.AddTransient<IArticleApplication, ArticleApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleValidatorServices, ArticleValidatorServices>();

            service.AddTransient<ICommentApplication, CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();

            service.AddTransient<IArticleQuery, ArticleQuery>();
            service.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
