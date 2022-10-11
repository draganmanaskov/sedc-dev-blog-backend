using DevBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBlog.DataAccess.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                    new Tag
                    {
                        Id = 1,
                        Value = "Architecture"
                    },
                    new Tag
                    {
                        Id = 2,
                        Value = "Design"
                    },
                    new Tag
                    {
                        Id = 3,
                        Value = "Tech"
                    },
                    new Tag
                    {
                        Id = 4,
                        Value = "Tips & Tricks"
                    }
               );
        }
    }
}
