using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(c => c.CreationDate).IsRequired();
            builder.Property(c => c.IsRemoved).IsRequired();

            builder.HasMany(c => c.Articles)
                .WithOne(c => c.ArticleCategory)
                .HasForeignKey(c => c.ArticleCategoryId);
        }
    }
}
