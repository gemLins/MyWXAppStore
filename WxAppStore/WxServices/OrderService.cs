using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices
{
   public class OrderService : BaseService
    {
        public OrderService(IConfiguration config) : base(config)
        {

        }

    }
}
