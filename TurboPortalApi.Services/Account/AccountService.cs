using System;
using System.Collections.Generic;
using System.Text;
using TurboPortalApi.Core;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Services.Account
{
    public partial class AccountService : IAccountService
    {
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<UserResourceMapping> _userResourceMappingRepository;
        private readonly IRepository<Resources> _resourcesRepository;

        public AccountService(
            IRepository<Users> userRepository,
            IRepository<UserResourceMapping> userResourceMappingRepository,
            IRepository<Resources> resourcesRepository)
        {
            this._userRepository = userRepository;
            this._userResourceMappingRepository = userResourceMappingRepository;
            this._resourcesRepository = resourcesRepository;
        }
    }
}
