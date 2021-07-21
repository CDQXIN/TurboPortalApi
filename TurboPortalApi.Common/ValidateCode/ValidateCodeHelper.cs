using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace TurboPortalApi.Common.ValidateCode
{
    public class ValidateCodeHelper
    {
        public static string CreateVaildateString(int len)
        {
            //设置允许出现的字符
            string chars = "abcdefghijklmnopqrstuvwxyz23456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //通过随机数生成验证码
            Random random = new Random();
            string validateString = "";
            for (int i = 0; i < len; i++)
            {
                validateString += chars[random.Next(chars.Length)];
            }
            return validateString;
        }
        public static byte[] CreateValidateCode(string validateCode)
        {
            /*
            **  创建画板并画画的过程 
            */
            //创建画布
            Bitmap bitmap = new Bitmap(validateCode.Length * 24, 30);
            //创建画笔
            Graphics graphics = Graphics.FromImage(bitmap);
            //给画布涂上背景色
            graphics.Clear(Color.White);
            //设置颜料板和调色刷
            RectangleF rf = new RectangleF(0, 0, bitmap.Width, bitmap.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rf, Color.Red, Color.DarkBlue, 1.2f, true);
            //设置需要画到图中文字的格式（字体，大小，是否加粗，斜体）
            Font font = new Font("Consolas", 16, FontStyle.Bold | FontStyle.Italic);
            //将字画到画板中
            graphics.DrawString(validateCode, font, brush, 0, 0);

            /*
            **  存储验证码并返回的过程
            */
            //创建一个可以用于保存图片的缓冲区
            MemoryStream memoryStream = new MemoryStream();
            //将图片存到缓冲区中
            bitmap.Save(memoryStream, ImageFormat.Jpeg);
            //Bitmap bitmap = new Bitmap(fs);
            //MemoryStream ms = new MemoryStream();
            //bitmap.Save(ms, ImageFormat.Png);

            //释放画板
            bitmap.Dispose();
            //返回byte[]
            return memoryStream.ToArray();
            //bitmap.Save(AppDomain.CurrentDomain.BaseDirectory + "aaa.jpg");
        }
    }
}
