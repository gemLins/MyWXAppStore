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
    public class ThemeApiController : ControllerBase
    {
        ThemeService _themeService;
        public ThemeApiController(ThemeService themeService)
        {
            _themeService = themeService;
        }
        public IActionResult getThemes()
        {
          var list = _themeService.getThemes();

            return Ok(list);
        }
    }
}