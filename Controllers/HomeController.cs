using ClinicManagement.ClinicModel;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicManagement.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("loggedInEmail") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "ClinicManagement");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]        
        [HttpPost]
        public IActionResult Index(Login l)
        {
            using (var db = new ClinicManagementContext())
            {
                User obj = (from i in db.Users
                                where i.LoginEmail == l.LoginEmail && i.LoginPassword == l.LoginPassword
                                select i).FirstOrDefault(); 
                if (obj != null)
                {                    
                    string loggedInEmail = obj.FirstName;
                    HttpContext.Session.SetString("loggedInEmail", loggedInEmail);                    
                    TempData["message"] = "You have logged in successfully";
                    return RedirectToAction("Index", "ClinicManagement");
                }
                else
                {
                    ViewBag.Message = "Bad user name or password";
                    return View();
                }
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
