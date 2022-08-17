using EdgeCloud.LES.ClassLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeCloud.LES.ClassLibrary.Repository.Configurations
{
    public class ApiRequestLogConfiguration : IEntityTypeConfiguration<ApiRequestLog>
    {
        public void Configure(EntityTypeBuilder<ApiRequestLog> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseMySqlIdentityColumn(); for mysql
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.AccessToken).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MacAddress).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ServerImportDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.ServerImportDate).IsRequired().HasColumnType("timestamp"); for mysql

            builder.Property(x => x.ContentType).HasMaxLength(10);
            builder.Property(x => x.RequestData).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.ResponseData).HasMaxLength(4000);
            builder.Property(x => x.RequestDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.RequestDate).IsRequired().HasColumnType("timestamp"); for mysql
            builder.Property(x => x.ResponseDate).IsRequired().HasColumnType("datetimeoffset(7)");
            //builder.Property(x => x.ResponseDate).IsRequired().HasColumnType("timestamp"); for mysql
            builder.Property(x => x.ErrorMessage).HasMaxLength(4000);
            builder.Property(x => x.ClientMessage).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.ModuleName).IsRequired().HasMaxLength(200);

        }
    }
}


