using ChessOnline.Controllers;
using ChessOnline.Networking;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessOnline
{
    public class ConnectionStart : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)// redirect to loginPage 
        {
            ClientSocket.StartClient();
            return next.Invoke(context);
        }
    }
}