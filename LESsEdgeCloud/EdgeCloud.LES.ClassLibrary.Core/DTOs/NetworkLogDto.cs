using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs
{
    public class NetworkLogDto : LogBaseDto
    {
        public UserNetworkType ActivityType { get; set; }
        public DateTimeOffset NetworkActivityDate { get; set; }
    }
}