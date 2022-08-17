using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Repository.DBContexts;

namespace EdgeCloud.LES.ClassLibrary.Repository.Repositories
{
    public class NavigationLogRepository : GenericRepository<NavigationLog>, INavigationLogRepository
    {
        public NavigationLogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
