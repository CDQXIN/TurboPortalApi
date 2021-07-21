using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboPortalApi.Api.Options;
using TurboPortalApi.Common.TokenHelper;
using TurboPortalApi.Entity;
using TurboPortalApi.Services.Account;

namespace TurboPortalApi.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public BaseController(IAccountService accountService, IConfiguration configuration, ItemOptions itemOptions)
        {
            this._accountService = accountService;
            this._configuration = configuration;
            ItemOptions = itemOptions;
        }

        public ItemOptions ItemOptions { get; }

        protected string CheckStatus(string qq, string pwd)
        {
            UserLoginResult userLoginResult = _accountService.ValidateLogin(qq, pwd);
            switch (userLoginResult)
            {
                case UserLoginResult.StopUse:
                    HttpContext.Response.StatusCode = 214;
                    return "用户已停用";
                case UserLoginResult.CustomerNoExist:
                    HttpContext.Response.StatusCode = 214;
                    return "用户不存在";
                case UserLoginResult.Deleted:
                    HttpContext.Response.StatusCode = 214;
                    return "用户已删除";
                case UserLoginResult.Successful:
                    var user = _accountService.GetUserByQQ(qq);
                    string res = TokenHelper.CreateToken(user.Id, Convert.ToInt32(_configuration["ExpTime"]));
                    return res;
                case UserLoginResult.WrongPassword:
                    HttpContext.Response.StatusCode = 214;
                    return "用户密码不正确";
                default:
                    HttpContext.Response.StatusCode = 214;
                    return "用户不存在";
            }
        }
    }
}
