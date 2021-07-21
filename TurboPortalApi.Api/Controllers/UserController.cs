using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboPortalApi.Api.Filters;
using TurboPortalApi.Api.Options;
using TurboPortalApi.Entity;
using TurboPortalApi.Services.Account;

namespace TurboPortalApi.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IAccountService accountService, IConfiguration configuration, ItemOptions itemOptions) : base(accountService, configuration, itemOptions)
        {
        }
        [TypeFilter(typeof(CtmActionFilter))]
        public Users GetUser(string token)
        {
            //int userId = (int)HttpContext.Items[WebOptions.userId];
            int userId = (int)ItemOptions.Items[WebOptions.userId];
            var user = _accountService.GetUserById(userId);
            return user;
        }

    }
}
