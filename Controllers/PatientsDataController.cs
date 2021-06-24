using ClinicManagement.ClinicModel;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Controllers
{
    public class PatientsDataController : Controller
    {
        readonly ClinicManagementContext db = new ClinicManagementContext();
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                return View(this.GetPatients(1));
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
                return View(this.GetPatients(currentPageIndex));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        private PatientsModel GetPatients(int currentPage)
        {
            int maxRows = 3;
            using (var entities = new ClinicManagementContext())
            {
                var customerModel = new PatientsModel();
                customerModel.Patients = (from patient in entities.Patients
                                         select patient)
                            .OrderBy(patient => patient.PatientName)
                            .Skip((currentPage - 1) * maxRows)
                            .Take(maxRows).ToList();

                double pageCount = (double)((decimal)entities.Patients.Count() / Convert.ToDecimal(maxRows));
                customerModel.PageCount = (int)Math.Ceiling(pageCount);

                customerModel.CurrentPageIndex = currentPage;

                return customerModel;
            }
        }
        public IActionResult AddPatient()
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
        public IActionResult AddPatient(Patient p)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                if (p != null)
                {
                    try
                    {                    
                        db.Patients.Add(p);
                        db.SaveChanges();
                    }
                    catch(Exception)
                    {
                        ViewBag.Duplicatekey = "Patient name already exist.";
                        return View();
                    }
                    TempData["message"] = "Patient name added successfully";
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
        public IActionResult PatientAppointments(string id)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                ViewBag.id = id;
                if(this.GetPatientsAppointments(1, id) != null)
                {
                    return View(this.GetPatientsAppointments(1, id));
                }
                else
                {
                    TempData["appointments"] = "No Appointments found";
                    return RedirectToAction("Index", "PatientsData");
                }
                    
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult PatientAppointments(int currentPageIndex, string id)
        {
            if (HttpContext.Session.GetString("loggedInEmail") != null)
            {
                ViewBag.id = id;
                return View(this.GetPatientsAppointments(currentPageIndex, id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        private AppointmentsModel GetPatientsAppointments(int currentPage, string id)
        {
            int maxRows = 3;
            using (ClinicManagementContext entities = new ClinicManagementContext())
            {
                AppointmentsModel customerModel = new AppointmentsModel();
                var dummy = entities.Appointments.Where(x => x.BkdPatient == id);
                if(!dummy.Any())
                {
                    return null;
                }
                customerModel.Appointments = (from appointment in entities.Appointments
                                              select appointment)
                                                .Where(x => x.BkdPatient == id)
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
