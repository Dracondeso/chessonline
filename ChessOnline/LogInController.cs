using ChessOnline.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessOnline
{
    public class LogInController : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
#if DEBUG
            string url = "https://localhost:5001//home/login";
#else
            string url = "www.urlinproduzione.it";
#endif

            if (context.Response.Cookies.Equals(null))
            {
                context.Response.Redirect(url);
            }




        }
    }
}
