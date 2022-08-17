using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Repository.DBContexts;

namespace EdgeCloud.LES.ClassLibrary.Repository.Repositories
{
    public class ApiRequestLogRepository : GenericRepository<ApiRequestLog>, IApiRequestLogRepository
    {
        public ApiRequestLogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
