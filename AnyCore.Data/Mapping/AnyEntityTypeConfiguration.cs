using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnyCore.Data.Mapping
{
    public abstract class AnyEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
