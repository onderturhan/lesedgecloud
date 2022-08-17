using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class InteractionLogService : Service<InteractionLog>, IInteractionLogService
    {
        private readonly IInteractionLogRepository _interactionLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InteractionLogService(IGenericRepository<InteractionLog> repository, IUnitOfWork unitOfWork, IInteractionLogRepository interactionLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _interactionLogRepository = interactionLogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<InteractionLogDto> AddAsync(InteractionLogDto insertedObject)
        {
            var entity = _mapper.Map<InteractionLog>(insertedObject);
            entity.ServerImportDate = DateTimeOffset.Now;
            await _interactionLogRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<InteractionLogDto>(entity);
        }
    }
}