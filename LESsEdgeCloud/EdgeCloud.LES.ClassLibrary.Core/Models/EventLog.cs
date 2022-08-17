using EdgeCloud.LES.ClassLibrary.Core.Enums;
using EdgeCloud.LES.ClassLibrary.Core.Models.Base;

namespace EdgeCloud.LES.ClassLibrary.Core.Models
{
    public class EventLog : LogBaseEntity
    {
        public UserEventType EventType { get; set; }
        public UserAPIServiceType ServiceType { get; set; }
    }
}