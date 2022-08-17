using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;
using System.Text.Json.Serialization;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs.Request
{
    public class FileTransferDto
    {
        public string RequestData { get; set; } = string.Empty;
        public object RequestDataObject { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;

        [JsonIgnore]
        public UserAPIServiceType EnumServiceType
        {
            get
            {
                Enum.TryParse(ServiceType, true, out UserAPIServiceType value);
                return value;
            }
        }
    }
}
