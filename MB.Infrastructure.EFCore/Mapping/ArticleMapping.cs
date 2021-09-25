using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title);
            builder.Property(c => c.ShortDescription);
            builder.Property(c => c.Content);
            builder.Property(c => c.Image);
            builder.Property(c => c.CreationDate);
            builder.Property(c => c.IsRemoved);

            builder.HasOne(c => c.ArticleCategory)
                .WithMany(c => c.Articles)
                .HasForeignKey(c => c.ArticleCategoryId);
        }
    }
}
