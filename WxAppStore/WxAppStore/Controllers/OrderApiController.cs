using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WxServices;

namespace WxAppStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        OrderService _orderService;
        public OrderApiController(OrderService orderService)
        {
            _orderService = orderService;
        }
    }
}
