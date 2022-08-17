using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class NavigationLogService : Service<NavigationLog>, INavigationLogService
    {
        private readonly INavigationLogRepository _navigationLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NavigationLogService(IGenericRepository<NavigationLog> repository, IUnitOfWork unitOfWork, INavigationLogRepository navigationLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _navigationLogRepository = navigationLogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<NavigationLogDto> AddAsync(NavigationLogDto insertedObject)
        {
            var entity = _mapper.Map<NavigationLog>(insertedObject);
            entity.ServerImportDate = DateTimeOffset.Now;
            await _navigationLogRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<NavigationLogDto>(entity);
        }
    }
}