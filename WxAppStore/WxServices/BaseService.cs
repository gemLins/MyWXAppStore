using CommonUtils;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices
{
    public class BaseService
    {
        public string ConnectionString { get; set; }
        public string WxTokenApiUrl { get; set; }
        public string WxAppId { get; set; }
        public string WxSecret { get; set; }
        public string imgUrl { get; set; }

        public BaseService(IConfiguration config)
        {
            WxTokenApiUrl = config.GetSection("AppSettings").GetSection("WxConfigUrl").Value;
            WxAppId = config.GetSection("AppSettings").GetSection("WxAppId").Value;
            WxSecret = config.GetSection("AppSettings").GetSection("WxSecret").Value;
            imgUrl = config.GetSection("AppSettings").GetSection("imgUrl").Value;
            this.ConnectionString = config.GetConnectionString("DefaultConnection");
        }
        private static Database database = null;

        private static object Lock = new object();
        public Database getDatabase()
        {
            return new Database(this.ConnectionString, "MySql");
        }
        /// <summary>
        /// 32个字符组成一组随机数组
        /// </summary>
        public string generateToken()
        {
            //用三组字符串进行md5加密

            string randchar = RandomStringBuilder.Create(32);


            return randchar;

        }


    }
}
