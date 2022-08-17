using Autofac;
using Autofac.Extensions.DependencyInjection;
using EdgeCloud.LES.ClassLibrary.Repository.DBContexts;
using EdgeCloud.LES.ClassLibrary.Service.Mapping;
using EdgeCloud.LES.WorkerService.FileRouting;
using EdgeCloud.LES.WorkerService.FileRouting.Modules;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (builder, services) =>
        {
            services.AddHostedService<Worker>();

            services.AddAutoMapper(typeof(MapProfile));

            //for mysql dotnet add package Pomelo.EntityFrameworkCore.MySql
            //services.AddDbContext<AppDbContext>(
            //    options =>
            //    options.UseMySql(
            //        builder.Configuration.GetConnectionString("SqlConnection"),
            //        ServerVersion.Create(
            //            new Version(10, 7),
            //            Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb),
            //        mySqlOptions =>
            //        {
            //            mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(60), null);

            //            mySqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
            //        }
            //    )
            //);

            //for mssql --dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            services.AddDbContext<AppDbContext>(
                options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("SqlConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                    }
                )
            );
        }
    )
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())//autofac definition-1
    .ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutofacModule()))//autofac definition-2
    .Build();

await host.RunAsync();
