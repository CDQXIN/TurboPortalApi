using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboPortalApi.Entity;
using TurboPortalApi.Services.Account.Dto;

namespace TurboPortalApi.Services.Account
{
    public interface IAccountService
    {
        IQueryable<Users> ListUserAll();
        Users GetUserById(int id);
        Users GetUserByQQ(string qq);
        int CreateAndUpdateUsers(UserInputDto userInputDto);
        void DeleteUser(int id);
        UserLoginResult ValidateLogin(string qq, string password);
        IQueryable<int> GetResourceIdsByUserId(int userId);
        List<ResourceByListDto> ListResourceAll();
        ResourceDto ListResourceById(int id);
        List<ResourceByListDto> ListResourcesByIds(IEnumerable<int> ids);
        List<ResourceByListDto> ListResourcesByUserId(int id);
    }
}
