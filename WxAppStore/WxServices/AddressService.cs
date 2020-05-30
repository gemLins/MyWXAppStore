using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using ZergDB;

namespace WxServices
{
    public class AddressService : BaseService
    {
        public AddressService(IConfiguration config) : base(config)
        {

        }


        public List<user_address> getUserAddress()
        {
            string userid = TokenService.UserID;
            using (var db = base.getDatabase())
            {
                List<user_address> list = db.Fetch<user_address>("select * from user_address where user_id =@0  ", userid);

                return list;
            }

        }
        public user_address getDefaultAddress()
        {
            string userid = TokenService.UserID;
            using (var db = base.getDatabase())
            {
                user_address list = db.FirstOrDefault<user_address>("select   * from user_address where user_id =@0 and isDefault=1 ", userid);
                if (list == null)
                {
                    list = db.FirstOrDefault<user_address>("select top 1  * from user_address where user_id =@0  order by id desc ", userid);
                }

                return list;
            }

        }
        public bool SetAddress(user_address address)
        {

            using (var db = base.getDatabase())
            {
                user_address oldadd = db.FirstOrDefault<user_address>("SELECT * FROM `user_address` where city =@0 and country = @1 and detail = @2 and user_id=@3", address.city, address.country, address.detail, TokenService.UserID);
                if (oldadd != null)
                {
                    oldadd.name = address.name;
                    oldadd.mobile = address.mobile;
                    oldadd.user_id = address.user_id;
                    return db.Update(oldadd) > 0 ? true : false;
                }
                else
                {
                    address.user_id = int.Parse(TokenService.UserID);
                    return db.Insert(address) != null ? true : false;
                }

            }

        }
    }
}
