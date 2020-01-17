﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChessOnline.Models;
using ChessOnline.Networking;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ChessOnline.Controllers
{
    public class HomeController : Controller
    {
        private string DbPsw1 = "1234";
        private string DbUser1 = "user1";
        private string DbPsw2 = "1234";
        private string DbUser2 = "user2";
        public IActionResult LogIn(User user)
        {
            return View();
        }//LoginPage for insert Username and Password
        public IActionResult Index(User user)
        {
            if (LogInControl(user))
            {
                return View();
            }
            else
            {
                return View("LogIn", user);
            }
        }//Index Page who call LogInControl 
        public bool LogInControl(User user)
        {
            if ((user.Password == DbPsw1 && user.UserName == DbUser1)|| (user.Password == DbPsw2 && user.UserName == DbUser2))
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.UtcNow.AddHours(1);
                options.IsEssential = true;
                string json = JsonConvert.SerializeObject(user);
                HttpContext.Response.Cookies.Append("AuthCookie", json, options);
                return true;
            }
            return false;
        }//Check if exists UserName and Password
        public IActionResult WaitingPage(User user)
        {
            return View();
        }
        public IActionResult ChessBoard()
        {
            return View();
        }//ChessBoard for admitted player
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}
