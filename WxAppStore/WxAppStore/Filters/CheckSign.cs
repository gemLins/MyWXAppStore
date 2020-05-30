using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WxAppStore.Filters
{
    public class CheckSign : ActionFilterAttribute
    { 
        HttpContext HttpContext { get; set; }

        bool hasExecuting = false;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
             
            await base.OnActionExecutionAsync(context, next);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
        }

      
      
    }
}
