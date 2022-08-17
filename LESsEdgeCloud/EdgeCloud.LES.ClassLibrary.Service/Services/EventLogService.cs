using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.Models;
using EdgeCloud.LES.ClassLibrary.Core.Repositories;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Core.UnitOfWorks;

namespace EdgeCloud.LES.ClassLibrary.Service.Services
{
    public class EventLogService : Service<EventLog>, IEventLogService
    {
        private readonly IEventLogRepository _eventLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventLogService(IGenericRepository<EventLog> repository, IUnitOfWork unitOfWork, IEventLogRepository eventLogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _eventLogRepository = eventLogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<EventLogDto> AddAsync(EventLogDto insertedObject)
        {
            var entity = _mapper.Map<EventLog>(insertedObject);
            entity.ServerImportDate = DateTimeOffset.Now;
            await _eventLogRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<EventLogDto>(entity);
        }
    }
}