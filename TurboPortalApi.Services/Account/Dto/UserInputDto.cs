using System;
using System.Collections.Generic;
using System.Text;
using TurboPortalApi.Entity;

namespace TurboPortalApi.Services.Account.Dto
{
    public class UserInputDto: FullEntityDto
    {
        public string QQ { get; set; }
        public string Mobile { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }
        public DateTime RegDate { get; set; }
        public int LoginNum { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public byte Status { get; set; }
        public string validateCode { get; set; }

        public static Users ToUpdateUsers(ref Users user ,UserInputDto userInputDto) {

            user.QQ = userInputDto.QQ;
            user.LastLoginTime = userInputDto.LastLoginTime;
            user.LastModifierId = userInputDto.LastModifierId;
            user.LastModifyTime = DateTime.Now;
            user.Mobile = userInputDto.Mobile;
            user.NickName = userInputDto.NickName;
            user.PassWord = userInputDto.PassWord;
            user.RegDate = userInputDto.RegDate;
            user.Status = userInputDto.Status;
            
            return user;
        }
        public static Users ToCreateUsers(UserInputDto userInputDto)
        {
            Users users = new Users
            {
                QQ = userInputDto.QQ,
                CreateTime = DateTime.Now,
                CreatorId = userInputDto.CreatorId,
                Mobile = userInputDto.Mobile,
                NickName = userInputDto.NickName,
                PassWord = userInputDto.PassWord,
                RegDate = userInputDto.RegDate,
                Status = userInputDto.Status
            };
            return users;
        }
    }
}
