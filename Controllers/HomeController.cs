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

//using Xceed.Wpf.Toolkit;

namespace ClinicManagement.Controllers
{
    public class HomeController : Controller
    {
        //Login l = new Login();       

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            if (HttpContext.Session.GetString("loggedInEmail")  == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "ClinicManagement");
            }
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Login(Login l)
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
                    ViewBag.Message = 1;
                    return RedirectToAction("Index", "ClinicManagement");
                    //return View();
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = 0;
                    return RedirectToAction("Index", "Home");
                    //return View();
                }
            }
        }
        //[HttpPost]
        //public IActionResult LoginAfterAlert(string l)
        //{
        //    if (l == "1")
        //    {
        //        return RedirectToAction("Index", "ClinicManagement");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
