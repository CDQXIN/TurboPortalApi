using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboPortalApi.Common.SecurityHelper;
using TurboPortalApi.Entity;
using TurboPortalApi.Services.Account.Dto;

namespace TurboPortalApi.Services.Account
{
    public partial class AccountService : IAccountService
    {
        public IQueryable<Users> ListUserAll()
        {
            return _userRepository.ListAll().Where(m => m.Status != 0);
        }
        public Users GetUserById(int id)
        {
            return _userRepository.ListById(id).FirstOrDefault();
        }
        public Users GetUserByQQ(string qq)
        {
            return _userRepository.ListByCustom(m => m.QQ == qq).FirstOrDefault();
        }
        public int CreateAndUpdateUsers(UserInputDto userInputDto)
        {
            if (userInputDto.Id == 0)
            {
                return InsertUsers(userInputDto);
            }
            else
            {
                return UpdateUsers(userInputDto);
            }

        }
        private int UpdateUsers(UserInputDto userInputDto)
        {
            var user = _userRepository.ListById(userInputDto.Id).FirstOrDefault();
            UserInputDto.ToUpdateUsers(ref user, userInputDto);
            return _userRepository.Update(user);
        }
        private int InsertUsers(UserInputDto userInputDto)
        {
            var user = UserInputDto.ToCreateUsers(userInputDto);
            return _userRepository.Insert(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public UserLoginResult ValidateLogin(string qq, string password)
        {
            var user = _userRepository.ListByCustom(m => m.QQ == qq).FirstOrDefault();
            if (user == null)
                return UserLoginResult.CustomerNoExist;
            if (user.Status == 0)
                return UserLoginResult.Deleted;
            if (user.Status == 2)
                return UserLoginResult.StopUse;
            string pwd = "";
            pwd = password.ToMd5();
            bool isValid = pwd == user.PassWord;
            if (!isValid)
                return UserLoginResult.WrongPassword;

            //save last login
            user.LastLoginTime = DateTime.Now;
            user.LoginNum++;
            _userRepository.Update(user);
            return UserLoginResult.Successful;
        }
    }
}
