using EdgeCloud.LES.ClassLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EdgeCloud.LES.ClassLibrary.Repository.DBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApiRequestLog> ApiRequestLogs { get; set; }
        public DbSet<UserAuthenticationLog> AuthenticationLogs { get; set; }
        public DbSet<InteractionLog> InteractionLogs { get; set; }
        public DbSet<NavigationLog> NavigationLogs { get; set; }
        public DbSet<NetworkLog> NetworkLogs { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //this method is for fluent api, it runs all Configurations in Configurations directory
            //Allows configuration to be performed for an entity type in a model

            base.OnModelCreating(modelBuilder);
        }
    }
}
