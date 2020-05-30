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
    public class BannerApiController : ControllerBase
    {
        BannerService bnservice;
        public BannerApiController(BannerService banner) {
            bnservice = banner;
        }

        // GET: api/BannerApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BannerApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet]
        public IActionResult GetAllBanner() {
           var list= bnservice.GetAllBanners();
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetAllBannerItems(string id)
        {
            var list = bnservice.GetAllBannerItems(id);
            return Ok(list);
        }
        // POST: api/BannerApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BannerApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
