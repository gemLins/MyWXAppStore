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
    public class ProductApiController : ControllerBase
    {
        ProductService _productService;
        public ProductApiController(ProductService productService)
        {
            _productService = productService;
        }


        public IActionResult getRecents()
        {
            var list = _productService.getRecents();

            return Ok(list);
        }

        public IActionResult getThemeProducts(string id)
        {
            var list = _productService.getThemeProducts(id);

            return Ok(list);
        }
        public IActionResult getDetailInfo(string id)
        {
            var info = _productService.getDetailInfo(id);
            return Ok(info);
        }

        public IActionResult deleteOne(string id) {



            return Ok();
        }
    }
}