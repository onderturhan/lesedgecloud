﻿using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;

namespace EdgeCloud.LES.ClassLibrary.Core.DTOs
{
    public class UserAuthenticationLogDto : LogBaseDto
    {
        public UserAuthenticationType ActivityType { get; set; }
        public string ClientMessage { get; set; }
        public DateTimeOffset AuthActivityDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}