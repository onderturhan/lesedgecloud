using EdgeCloud.LES.ClassLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeCloud.LES.ClassLibrary.Repository.Configurations
{
    public class UserAuthenticationLogConfiguration : IEntityTypeConfiguration<UserAuthenticationLog>
    {
        public void Configure(EntityTypeBuilder<UserAuthenticationLog> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseMySqlIdentityColumn(); for mysql
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.AccessToken).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MacAddress).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ServerImportDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.ServerImportDate).IsRequired().HasColumnType("timestamp"); for mysql

            builder.Property(x => x.ActivityType).HasConversion<int>();
            builder.Property(x => x.ClientMessage).HasMaxLength(4000);
            builder.Property(x => x.AuthActivityDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.ActivityDate).IsRequired().HasColumnType("timestamp"); for mysql
            builder.Property(x => x.ErrorMessage).HasMaxLength(4000);
        }
    }
}
