using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboPortalApi.Api.Filters;
using TurboPortalApi.Api.Options;
using TurboPortalApi.Services.Account;
using TurboPortalApi.Services.Account.Dto;

namespace TurboPortalApi.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ResourceController : BaseController
    {
        public ResourceController(IAccountService accountService, IConfiguration configuration, ItemOptions itemOptions) : base(accountService, configuration, itemOptions)
        {
        }
        /// <summary>
        /// 获取所有的课程资源
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ResourceByListDto> GetResourceList()
        {
            var res = _accountService.ListResourceAll();
            return res;
        }
        /// <summary>
        /// 获取当前用户已有的课程Id们
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [TypeFilter(typeof(CtmActionFilter))]
        public IEnumerable<int> GetResourceId(string token)
        {
            var userId = (int)ItemOptions.Items[WebOptions.userId];
            var res = _accountService.GetResourceIdsByUserId(userId).ToList();
            return res;
        }
        /// <summary>
        /// 根据Id获取资源详情
        /// </summary>
        /// <param name="id">资源id</param>
        /// <param name="token"></param>
        /// <returns></returns>
        [TypeFilter(typeof(CtmActionFilter))]
        public ResourceDto GetResourceById(int id, string token)
        {
            var userId = (int)ItemOptions.Items[WebOptions.userId];
            var ids = _accountService.GetResourceIdsByUserId(userId).ToList();
            if (ids.Contains(id))
            {
                return _accountService.ListResourceById(id);
            }
            else
            {
                HttpContext.Response.StatusCode = 204;
                return default;
            }
        }
    }
}
