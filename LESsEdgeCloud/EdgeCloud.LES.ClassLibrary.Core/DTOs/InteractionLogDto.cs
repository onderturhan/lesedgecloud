using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs
{
    public class InteractionLogDto : LogBaseDto
    {
        public string ClientMessage { get; set; }
        public DateTimeOffset InteractionActivityDate { get; set; }
    }
}