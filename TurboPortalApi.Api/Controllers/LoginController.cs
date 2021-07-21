using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using TurboPortalApi.Api.Options;
using TurboPortalApi.Common.MemoryHelper;
using TurboPortalApi.Common.ValidateCode;
using TurboPortalApi.Entity;
using TurboPortalApi.Services.Account;
using TurboPortalApi.Services.Account.Dto;

namespace TurboPortalApi.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(IAccountService accountService, IConfiguration configuration, ItemOptions itemOptions) : base(accountService, configuration, itemOptions)
        {
        }
        public string CheckLogin(string qq, string pwd, string validateString)
        {
            string orgIp = HttpContext.Connection.RemoteIpAddress.ToString();
            string ip = orgIp == "::1" ? "127.0.0.1" : orgIp;
            string validate = MemoryCacheHelper.GetCache(ip).ToString();
            if (validate != null && validateString.ToLower() == validate.ToLower())
            {
                return CheckStatus(qq, pwd);
            }
            else
            {
                HttpContext.Response.StatusCode = 214;
                return "验证码错误";
            }
        }

        public string AddUser(UserInputDto userInputDto)
        {
            string ip = HttpContext.Connection.RemoteIpAddress.ToString();
            string validateCode = MemoryCacheHelper.GetCache(ip).ToString();
            if (!string.IsNullOrEmpty(validateCode) && validateCode.ToLower() == userInputDto.validateCode)
            {
                Users user;
                user = _accountService.GetUserByQQ(userInputDto.QQ);
                if (user != null)
                {
                    HttpContext.Response.StatusCode = 214;
                    return "hasQQ";
                }
                int row = _accountService.CreateAndUpdateUsers(userInputDto);
                if (row >= 1) return "success";
                else
                {
                    HttpContext.Response.StatusCode = 214;
                    return "UnknowErr";
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 214;
                return "ValidateErr";
            }
        }

        public IActionResult GetValidateCode()
        {
            string validateString = ValidateCodeHelper.CreateVaildateString(4);
            byte[] buffer = ValidateCodeHelper.CreateValidateCode(validateString);
            string orgIp = HttpContext.Connection.RemoteIpAddress.ToString();
            string ip = orgIp == "::1" ? "127.0.0.1" : orgIp;
            MemoryCacheHelper.SetCache(ip, validateString);
            return File(buffer, @"image/png");
        }


        [HttpPost]
        public string GetFile(List<IFormFile> img)
        {
            //var files =  Request.Form.Files;
            if (img.Count < 1)
            {
                return "文件为空";
            }
            var now = DateTime.Now;
            //获取当前的Web目录
            var currFilePath = Path.Combine("update/");
            //获取根目录
            var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", currFilePath);
            //判断目类是否存在
            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);

            }

            foreach (var item in img)
            {
                if (item != null)
                {
                    //文件后缀
                    var fileExt = Path.GetExtension(item.FileName);
                    //判断后缀是否是图片
                    const string fileFilt = ".gif|.jpg|.jpeg|.png";
                    if (fileExt == null)
                    {
                        break;
                    }
                    //var fileFilts = fileFilt.Split('|');
                    //if(fileFilts.Contains(fileExt.ToLower()))
                    if (fileFilt.IndexOf(fileExt.ToLower(), StringComparison.Ordinal) <= -1)
                    {
                        break;
                    }
                    //判断文件大小
                    long length = item.Length;
                    if (length > 2048 * 1000)
                    {
                        break;
                    }
                    var saveTagName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_tag" + fileExt;
                    var saveName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExt;

                    var image = SetTag(item.OpenReadStream());
                    image.Save(webRootPath + saveTagName);

                    using (FileStream fs = System.IO.File.Create(webRootPath + saveName))
                    {
                        item.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
            return "OK";
        }
        public Image SetTag(Stream stream)
        {
            //从流中获取图片，作为画板
            Image img = Image.FromStream(stream);
            //准备一支画笔并和画板做关联
            Graphics g = Graphics.FromImage(img);
            //获取图片尺寸
            var size = img.Size;
            //用画笔画水印
            g.DrawString("Ace",
                 new Font("Consolas", size.Width / 10, FontStyle.Italic),
                 Brushes.Blue, size.Width / 2 - size.Width / 10 / 2, size.Height / 2);
            return img;
        }
    }
}
