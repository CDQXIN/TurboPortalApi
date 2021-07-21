using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboPortalApi.Services.Account
{
    public partial class AccountService : IAccountService
    {
        public IQueryable<int> GetResourceIdsByUserId(int userId)
        {
            var resources = _userResourceMappingRepository.ListByCustom(m => m.UserId == userId);
            var resourceIds = resources.Select(m => m.ResourceId);
            return resourceIds;
        }
    }
}
