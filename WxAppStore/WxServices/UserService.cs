 
using Microsoft.Extensions.Configuration;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using ZergDB;

namespace WxServices
{
    public class UserService : BaseService
    {
        public UserService(IConfiguration iconf) : base(iconf)
        {

        }

        public string getToken(string code)
        {
            Sql sql = new Sql("select ");

            return "";
        }
        public user grantToken(Jscode2sessionResult j2sResult)
        {
            using (var db = base.getDatabase())
            {
                var nowuser = db.FirstOrDefault<user>("where openid=@0", j2sResult.openid);
                if (nowuser == null)
                {
                    user u = new user()
                    {
                        openid = j2sResult.openid,
                         create_time = DateTime.Now

                    };
                    user newuser = (user)db.Insert("user", u);
                    return newuser;
                }
                else
                {
                    return nowuser;
                }

            }
        }

    }
}
