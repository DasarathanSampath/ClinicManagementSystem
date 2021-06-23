using ClinicManagement.ClinicModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace ClinicManagement.Controllers
{
    public class DropdownController : Controller
    {
        ClinicManagementContext db = new ClinicManagementContext();
                
        public JsonResult GetDoctors()
        {
            List<string> doctorsList = db.Doctors.Select(x => x.DoctorName).ToList();            
            return Json(doctorsList);            
        }
        
        public JsonResult GetPatients()
        {
            List<string> patientList = db.Patients.Select(x => x.PatientName).ToList();
            return Json(patientList);
        }
        [HttpPost]
        public JsonResult GetSlots(string doctor, DateTime date)
        {
            IEnumerable<Appointment> lisAppointments = db.Appointments.Where(x => x.AppDoctor == doctor && (x.BookingDate) == date.Date).ToList();
            var dummlyAppointments = lisAppointments;
            dummlyAppointments = dummlyAppointments.Where(pu => !lisAppointments  // your List<string>
                                    .Any(str => pu.BookingSlot == -(str.BookingSlot)));            
            var bookedSlots = dummlyAppointments.Select(x => x.BookingSlot);                        
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            int y = 6;
            foreach (var item in bookedSlots)
            {                
                for (int i = 0; i < y; i++)
                {
                    if(list[i] == item)
                    {
                        list.Remove((int)item);
                        y = y - 1;
                    }
                }

            }
            var availableSlots = list;
            return Json(availableSlots);
        }
        
    }
}
