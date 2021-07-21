using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TurboPortalApi.Common.SecurityHelper;

namespace TurboPortalApi.Common.TokenHelper
{
    public class TokenHelper
    {
        /// <summary>
        /// 创建token
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="expMin">过期时长</param>
        /// <returns></returns>
        public static string CreateToken(int userId, int expMin)
        {
            //获取token过期时间点
            DateTime dateTimeExp = DateTime.Now.AddMinutes(expMin);
            //生成dynamic类型
            var tokenData = new { userId, dateTimeExp };
            //对加密数据序列化
            var tokenOrg = JsonConvert.SerializeObject(tokenData);
            //对Token原始数据进行加密处理
            string token = tokenOrg.Encrypt();
            return token;
        }
        public static (int userId, bool isExp) UnlockToken(string token)
        {
            //解密Token
            string tokenDec = token.Decrypt();
            if (tokenDec != null)
            {
                //对token反序列化并解析成dynamic累心
                dynamic tokenData = JsonConvert.DeserializeObject<dynamic>(tokenDec);
                //获取过期时间并判断
                var dateTimeExp = (DateTime)tokenData.dateTimeExp;
                bool isExp = false;
                //如果小于过期时间则说明token已过期
                if (dateTimeExp < DateTime.Now)
                {
                    isExp = true;
                }
                return ((int)tokenData.userId, isExp);
            }
            return (0, true);
        }
    }
}
