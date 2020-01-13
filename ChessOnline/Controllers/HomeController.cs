using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChessOnline.Models;
using ChessOnline.Networking;

namespace ChessOnline.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            ClientSocket.StartClient();
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ChessBoard()
        {
            return View();
        }
        public void LogInControl(User user)
        {
            View("login");
         //   View("nomeview", eventualeoggetto)
        }
    }
}
