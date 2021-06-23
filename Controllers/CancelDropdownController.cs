using ClinicManagement.ClinicModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Controllers
{
    public class CancelDropdownController : Controller
    {
        ClinicManagementContext db = new ClinicManagementContext();       

        public JsonResult GetPatientsForCancel()
        {
            List<string> patientList = db.Patients.Select(x => x.PatientName).ToList();
            return Json(patientList);
        }
        [HttpPost]
        public JsonResult GetDoctorsByPatient(string patient)
        {
            IEnumerable<Appointment> lisAppointments = db.Appointments.Where(x => x.BkdPatient == patient).ToList();
            var doctorsList = lisAppointments.Select(x => x.AppDoctor).Distinct();
            //List<string> doctorsList = db.Doctors.Select(x => x.DoctorName).ToList();
            return Json(doctorsList);
        }
        [HttpPost]
        public JsonResult GetBookedDate(string doctor, string patient)
        {
            IEnumerable<Appointment> lisAppointments = db.Appointments.Where(x => x.AppDoctor == doctor && (x.BkdPatient) == patient).ToList();
            var bookedDates = lisAppointments.Select(x => x.BookingDate);
            return Json(bookedDates);
        }
        [HttpPost]
        public JsonResult GetBookedSlots(string doctor, string patient, DateTime date)
        {
            IEnumerable<Appointment> lisAppointments = db.Appointments.Where(x => x.AppDoctor == doctor && (x.BookingDate) == date.Date && (x.BkdPatient) == patient).ToList();
            var dummlyAppointments = lisAppointments;
            dummlyAppointments = dummlyAppointments.Where(pu => !lisAppointments  // your List<string>
                                    .Any(str => pu.BookingSlot == -(str.BookingSlot)));
            var bookedSlots = dummlyAppointments.Select(x => x.BookingSlot);
            return Json(bookedSlots);
        }

    }
}
