using ClinicManagement.ClinicModel;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace ClinicManagement.Controllers
{
    public class DoctorsDataController : Controller
    {
        ClinicManagementContext db = new ClinicManagementContext();
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
            using (ClinicManagementContext entities = new ClinicManagementContext())
            {
                DoctorsModel customerModel = new DoctorsModel();

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
                        throw;
                    }
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
                return View(this.GetDoctorAppointments(1, id));
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
                //AppointmentsModel dummyEntities = new AppointmentsModel();
                //dummyEntities.Appointments = entities.Appointments.Where(x => x.AppDoctor == id).ToList();
                customerModel.Appointments = (from appointment in entities.Appointments
                                         select appointment)
                            .Where(x => x.AppDoctor == id)
                            .OrderByDescending(appointment => appointment.BookingDate)
                            .Skip((currentPage - 1) * maxRows)
                            .Take(maxRows).ToList();

                double pageCount = (double)((decimal)entities.Appointments.Count() / Convert.ToDecimal(maxRows));
                customerModel.PageCount = (int)Math.Ceiling(pageCount);

                customerModel.CurrentPageIndex = currentPage;

                return customerModel;
            }
        }

    }
}
