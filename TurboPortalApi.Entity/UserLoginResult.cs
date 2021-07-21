using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPortalApi.Entity
{
    public enum UserLoginResult
    {
        StopUse,
        CustomerNoExist,
        Deleted,
        Successful,
        WrongPassword,
    }
}
