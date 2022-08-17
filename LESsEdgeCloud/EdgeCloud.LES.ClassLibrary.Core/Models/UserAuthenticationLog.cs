using EdgeCloud.LES.ClassLibrary.Core.Models.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;

namespace EdgeCloud.LES.ClassLibrary.Core.Models
{
    public class UserAuthenticationLog : LogBaseEntity
    {
        public UserAuthenticationType ActivityType { get; set; }
        public string ClientMessage { get; set; }
        public DateTimeOffset AuthActivityDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}