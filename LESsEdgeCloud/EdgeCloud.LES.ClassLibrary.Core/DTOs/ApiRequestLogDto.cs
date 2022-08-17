using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs
{
    public class ApiRequestLogDto : LogBaseDto
    {
        public string ContentType { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public DateTimeOffset ResponseDate { get; set; }
        public string ErrorMessage { get; set; }
        public string ClientMessage { get; set; }
        public string ModuleName { get; set; }
    }
}