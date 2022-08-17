using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class UserAuthenticationLogService : Service<UserAuthenticationLog>, IUserAuthenticationLogService
    {
        private readonly IUserAuthenticationLogRepository _authenticationLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserAuthenticationLogService(IGenericRepository<UserAuthenticationLog> repository, IUnitOfWork unitOfWork, IUserAuthenticationLogRepository authenticationLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _authenticationLogRepository = authenticationLogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserAuthenticationLogDto> AddAsync(UserAuthenticationLogDto insertedObject)
        {
            var entity = _mapper.Map<UserAuthenticationLog>(insertedObject);
            entity.ServerImportDate = DateTimeOffset.Now;
            await _authenticationLogRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserAuthenticationLogDto>(entity);
        }
    }
}
