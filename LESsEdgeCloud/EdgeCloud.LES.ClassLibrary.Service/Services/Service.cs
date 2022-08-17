using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
