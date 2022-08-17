using Autofac;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;
using EdgeCloud.LES.ClassLibrary.Repository.DBContexts;
using EdgeCloud.LES.ClassLibrary.Repository.Repositories;
using EdgeCloud.LES.ClassLibrary.Repository.UnitOfWorks;
using EdgeCloud.LES.ClassLibrary.Service.Mapping;
using EdgeCloud.LES.ClassLibrary.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace EdgeCloud.LES.WorkerService.FileRouting.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope(); // InstancePerLifetimeScope method is equal to "AddScope" in definition of program.cs, also InstancePerDependency is to "AddTransient"..

            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            var serviceWorkerLayerAssembly = Assembly.GetExecutingAssembly();
            var repositoryLayerAssembly = Assembly.GetAssembly(typeof(AppDbContext)); //The description of AppDbContext doesnt matter, I require to find assembly which covers it out
            var serviceLayerAssembly = Assembly.GetAssembly(typeof(MapProfile)); //The description of MapProfile doesnt matter, I require to find assembly which covers it out

            builder.RegisterAssemblyTypes(
                        serviceWorkerLayerAssembly,
                        serviceLayerAssembly,
                        repositoryLayerAssembly)
                .Where(x => x.Name.EndsWith("Repository") || x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
