using EdgeCloud.LES.ClassLibrary.Core.Models.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;

namespace EdgeCloud.LES.ClassLibrary.Core.Models
{
    public class NetworkLog : LogBaseEntity
    {
        public UserNetworkType ActivityType { get; set; }
        public DateTimeOffset NetworkActivityDate { get; set; }
    }
}