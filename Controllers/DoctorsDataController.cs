using ClinicManagement.ClinicModel;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Controllers
{
    public class DoctorsDataController : Controller
    {
        readonly ClinicManagementContext db = new ClinicManagementContext();        
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                return View(this.GetDoctors(1));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Index(int currentPageIndex)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                return View(this.GetDoctors(currentPageIndex));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        private DoctorsModel GetDoctors(int currentPage)
        {
            int maxRows = 3;
            using (var entities = new ClinicManagementContext())
            {
                var customerModel = new DoctorsModel();
                customerModel.Doctors = (from doctor in entities.Doctors
                                         select doctor)
                            .OrderBy(doctor => doctor.DoctorName)
                            .Skip((currentPage - 1) * maxRows)
                            .Take(maxRows).ToList();

                double pageCount = (double)((decimal)entities.Doctors.Count() / Convert.ToDecimal(maxRows));
                customerModel.PageCount = (int)Math.Ceiling(pageCount);

                customerModel.CurrentPageIndex = currentPage;

                return customerModel;
            }
        }
        public IActionResult AddDoctor()
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor d)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                if (d != null)
                {
                    try
                    {
                        db.Doctors.Add(d);
                        db.SaveChanges();
                    }
                    catch(Exception)
                    {
                        ViewBag.Duplicatekey = "Doctor name already exist.";
                        return View();
                    }
                    TempData["message"] = "Doctor name added successfully";
                    return RedirectToAction("Index");
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
        public IActionResult DoctorAppointments(string id)
        {            
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                ViewBag.id = id;
                if (this.GetDoctorAppointments(1, id) != null)
                {
                    return View(this.GetDoctorAppointments(1, id));
                }
                else
                {
                    TempData["appointments"] = "No Appointments found";
                    return RedirectToAction("Index", "DoctorsData");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult DoctorAppointments(int currentPageIndex, string id)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                ViewBag.id = id;
                return View(this.GetDoctorAppointments(currentPageIndex, id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        private AppointmentsModel GetDoctorAppointments(int currentPage, string id)
        {
            int maxRows = 3;
            using (ClinicManagementContext entities = new ClinicManagementContext())
            {
                AppointmentsModel customerModel = new AppointmentsModel();
                var dummy = entities.Appointments.Where(x => x.AppDoctor == id);
                if (!dummy.Any())
                {
                    return null;
                }
                customerModel.Appointments = (from appointment in entities.Appointments
                                              select appointment)
                                                .Where(x => x.AppDoctor == id)
                                                .OrderByDescending(appointment => appointment.BookingDate)
                                                .Skip((currentPage - 1) * maxRows)
                                                .Take(maxRows).ToList();

                double pageCount = (double)((decimal)dummy.Count() / Convert.ToDecimal(maxRows));
                customerModel.PageCount = (int)Math.Ceiling(pageCount);
                customerModel.CurrentPageIndex = currentPage;
                return customerModel;
            }
        }

    }
}
