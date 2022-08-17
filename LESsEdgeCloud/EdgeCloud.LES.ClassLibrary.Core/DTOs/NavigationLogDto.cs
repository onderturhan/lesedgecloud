using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs
{
    public class NavigationLogDto : LogBaseDto
    {
        public string ClientMessage { get; set; }
        public DateTimeOffset NavigationActivityDate { get; set; }
    }
}