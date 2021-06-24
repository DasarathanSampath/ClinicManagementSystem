using ClinicManagement.ClinicModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace ClinicManagement.Controllers
{
    public class ClinicManagementController : Controller
    {
        readonly ClinicManagementContext db = new ClinicManagementContext();

        //public IEnumerable<Patient> PatientsList { get; private set; }

        public IActionResult Index()
        {
            ViewBag.loggedInEmail = HttpContext.Session.GetString("loggedInEmail");
            if(ViewBag.loggedInEmail != null)
            {
                return View();
            } 
            else
            {
                return RedirectToAction("Index", "Home");
            }                
        }
        //public IActionResult Doctors()
        //{
        //    ViewBag.loggedInEmail = HttpContext.Session.GetString("loggedInEmail");
        //    if (ViewBag.loggedInEmail != null)
        //    {
        //        return View(db.Doctors.ToList());
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //public IActionResult AddDoctor()
        //{
        //    if (HttpContext.Session.GetString("loggedInEmail") != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }                
        //}
        //[HttpPost]
        //public IActionResult AddDoctor(Doctor d)
        //{            
        //    if (HttpContext.Session.GetString("loggedInEmail") != null)
        //    {
        //        if (d != null)
        //        {
        //            db.Doctors.Add(d);
        //            db.SaveChanges();
        //            return RedirectToAction("Doctors");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }            
        //}
        //public IActionResult Patients()
        //{
        //    ViewBag.loggedInEmail = HttpContext.Session.GetString("loggedInEmail");
        //    if (ViewBag.loggedInEmail != null)
        //    {
        //        return View(db.Patients.ToList());
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //public IActionResult AddPatient()
        //{
        //    if (HttpContext.Session.GetString("loggedInEmail") != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //[HttpPost]
        //public IActionResult AddPatient(Patient p)
        //{
        //    if (HttpContext.Session.GetString("loggedInEmail") != null)
        //    {
        //        if (p != null)
        //        {
        //            db.Patients.Add(p);
        //            db.SaveChanges();
        //            return RedirectToAction("Patients");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //public IActionResult BookAnAppointment(string selectedDoctor="")
        public IActionResult BookAnAppointment()
        {            
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                ViewBag.PatientsList = new SelectList(db.Patients.Select(x => x.PatientName).Distinct());
                ViewBag.DoctorsList = new SelectList(db.Doctors.Select(x => x.DoctorName).Distinct());
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult BookAnAppointment(Appointment a)
        {
            //a.BookingSlot = Convert.ToInt32(a.BookingSlot);
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                if (a != null)
                {
                    db.Appointments.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ClinicManagement");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult CancelAnAppointment()
        {
            ViewBag.loggedInEmail = HttpContext.Session.GetString("loggedInEmail");
            if (ViewBag.loggedInEmail != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult CancelAnAppointment(Appointment a)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                if (a != null)
                {
                    a.BookingSlot = -(a.BookingSlot);
                    db.Appointments.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ClinicManagement");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


    }
}
