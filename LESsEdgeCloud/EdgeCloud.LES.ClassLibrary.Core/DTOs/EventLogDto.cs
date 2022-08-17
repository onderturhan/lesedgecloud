using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs
{
    public class EventLogDto : LogBaseDto
    {
        public UserEventType EventType { get; set; }
        public UserAPIServiceType ServiceType { get; set; }
    }
}