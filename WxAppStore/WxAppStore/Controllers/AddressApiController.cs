using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WxServices;
using ZergDB;

namespace WxAppStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressApiController : ControllerBase
    {
        AddressService _addressService;
        public AddressApiController(AddressService addressService)
        {
            _addressService = addressService;
        }
        public IActionResult getUserAddress( ) {
           
            var list = _addressService.getUserAddress( );

            return Ok(list);
        }
        public IActionResult getDefaultAddress( )
        {
 
            var list = _addressService.getDefaultAddress( );

            return Ok(list);
        }
        public IActionResult SetAddress(user_address address)
        {
            var flag = _addressService.SetAddress(address);

            return Ok(flag);
        }

    }
}