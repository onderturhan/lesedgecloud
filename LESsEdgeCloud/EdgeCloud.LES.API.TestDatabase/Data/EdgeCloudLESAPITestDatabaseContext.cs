#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdgeCloud.LES.API.TestDatabase.Model;

namespace EdgeCloud.LES.API.TestDatabase.Data
{
    public class EdgeCloudLESAPITestDatabaseContext : DbContext
    {
        public EdgeCloudLESAPITestDatabaseContext (DbContextOptions<EdgeCloudLESAPITestDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<EdgeCloud.LES.API.TestDatabase.Model.User> User { get; set; }

        public DbSet<EdgeCloud.LES.API.TestDatabase.Model.Address> Address { get; set; }

        public DbSet<EdgeCloud.LES.API.TestDatabase.Model.Company> Company { get; set; }
    }
}
