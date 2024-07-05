using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UneContChallenge.Infra.Mappings
{
    public class BaseMappings<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id");
            builder.Property("Id").IsRequired().HasColumnName("Id");
        }
    }
}
