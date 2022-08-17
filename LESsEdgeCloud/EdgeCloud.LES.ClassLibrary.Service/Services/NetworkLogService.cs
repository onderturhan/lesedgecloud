using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class NetworkLogService : Service<NetworkLog>, INetworkLogService
    {
        private readonly INetworkLogRepository _networkLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NetworkLogService(IGenericRepository<NetworkLog> repository, IUnitOfWork unitOfWork, INetworkLogRepository networkLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _networkLogRepository = networkLogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<NetworkLogDto> AddAsync(NetworkLogDto insertedObject)
        {
            var entity = _mapper.Map<NetworkLog>(insertedObject);
            entity.ServerImportDate = DateTimeOffset.Now;
            await _networkLogRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<NetworkLogDto>(entity);
        }
    }
}
