using EdgeCloud.LES.ClassLibrary.Core.Models.Base;

namespace EdgeCloud.LES.ClassLibrary.Core.Models
{
    public class InteractionLog : LogBaseEntity
    {
        public string ClientMessage { get; set; }
        public DateTimeOffset InteractionActivityDate { get; set; }
    }
}