using AnyCore.Core.Domain.ApplicationUser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnyCore.Data.Mapping.ApplicationUsers
{
    public class ApplicationUserMap : AnyEntityTypeConfiguration<ApplicationUser>
    {

        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.DisplayName).HasMaxLength(128).IsRequired();
            builder.Property(o => o.Email).IsRequired();
        }
    }
}
