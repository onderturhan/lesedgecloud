using EdgeCloud.LES.ClassLibrary.Core.Models.Base;

namespace EdgeCloud.LES.ClassLibrary.Core.Models
{
    public class NavigationLog : LogBaseEntity
    {
        public string ClientMessage { get; set; }
        public DateTimeOffset NavigationActivityDate { get; set; }
    }
}