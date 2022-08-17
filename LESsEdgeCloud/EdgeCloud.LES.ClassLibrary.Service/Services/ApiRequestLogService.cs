using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class ApiRequestLogService : Service<ApiRequestLog>, IApiRequestLogService
    {
        private readonly IApiRequestLogRepository _apiRequestLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ApiRequestLogService(IGenericRepository<ApiRequestLog> repository, IUnitOfWork unitOfWork, IApiRequestLogRepository apiRequestLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _apiRequestLogRepository = apiRequestLogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiRequestLogDto> AddAsync(ApiRequestLogDto insertedObject)
        {
            var entity = _mapper.Map<ApiRequestLog>(insertedObject);
            entity.ServerImportDate = DateTimeOffset.Now;
            await _apiRequestLogRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ApiRequestLogDto>(entity);
        }
    }
}
