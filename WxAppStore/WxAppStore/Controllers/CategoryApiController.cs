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
    public class CategoryApiController : ControllerBase
    {
        CategoryService _categoryService;

        public CategoryApiController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult getCategoryType()
        {
            var list = _categoryService.getCategoryType();
            return Ok(list);
        }

        public IActionResult getProductsByCategory(string id)
        {

            var list = _categoryService.getProductsByCategory(id);
            return Ok(list);
        }
    }
}