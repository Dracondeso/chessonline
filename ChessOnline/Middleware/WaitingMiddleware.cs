using ChessOnline.Controllers;
using ChessOnline.Networking;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChessOnline
{
    public class WaitingMiddleware : IMiddleware
    {
        private const string CookieKey = "AuthCookie";

        public Task InvokeAsync(HttpContext context, RequestDelegate next)// redirect to loginPage 
        {
            string url;
#if DEBUG
            url = @"https:\\localhost:5001\home\ChessBoard";
#else
            url = "www.urlinproduzione.it";
#endif
            if (context.Request.Path == "/home/WaitingPage")
            {
                ClientSocket.StartClient();
                context.Request.Cookies.TryGetValue(CookieKey, out string user);
      //          ClientSocket.SendMsg(user);
                context.Response.Redirect(url);
                
            }


            return next.Invoke(context);


        }
    }
}