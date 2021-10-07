using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name);
            builder.Property(c => c.Email);
            builder.Property(c => c.Message);
            builder.Property(c => c.Status);
            builder.Property(c => c.CreationDate);

            builder.HasOne(c => c.Article)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ArticleId);
        }
    }
}
