using EdgeCloud.LES.ClassLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeCloud.LES.ClassLibrary.Repository.Configurations
{
    public class NavigationLogConfiguration : IEntityTypeConfiguration<NavigationLog>
    {
        public void Configure(EntityTypeBuilder<NavigationLog> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseMySqlIdentityColumn(); for mysql
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.AccessToken).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MacAddress).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ServerImportDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.ServerImportDate).IsRequired().HasColumnType("timestamp"); for mysql

            builder.Property(x => x.ClientMessage).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.NavigationActivityDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.ActivityDate).IsRequired().HasColumnType("timestamp"); for mysql
        }
    }
}
