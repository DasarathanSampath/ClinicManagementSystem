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
        ClinicManagementContext db = new ClinicManagementContext();
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
            using (ClinicManagementContext entities = new ClinicManagementContext())
            {
                PatientsModel customerModel = new PatientsModel();

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
                    db.Patients.Add(p);
                    db.SaveChanges();
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
    }
}
