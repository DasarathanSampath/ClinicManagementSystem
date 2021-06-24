using ClinicManagement.ClinicModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClinicManagement.Controllers
{
    public class DropdownController : Controller
    {
        readonly ClinicManagementContext db = new ClinicManagementContext();

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
            var dummy = lisAppointments.Where(x => x.BookingSlot < 0);
            lisAppointments = lisAppointments.Where(pu => !dummy
                                                .Any(str => pu.BookingSlot == str.BookingSlot || pu.BookingSlot == -(str.BookingSlot)));
            var bookedSlots = lisAppointments.Select(x => x.BookingSlot);
            var list = new List<int>();
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
                    if (list[i] == item)
                    {
                        list.Remove((int)item);
                        y--;
                    }
                }

            }
            //var listTime = new List<string>();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i] == 1)
            //    {
            //        listTime.Add("10AM - 11AM");
            //    }
            //    else
            //    {
            //        if (list[i] == 2)
            //        {
            //            listTime.Add("11AM - 12PM");
            //        }
            //        else
            //        {
            //            if (list[i] == 3)
            //            {
            //                listTime.Add("12PM - 1PM");
            //            }
            //            else
            //            {
            //                if (list[i] == 4)
            //                {
            //                    listTime.Add("2PM - 3PM");
            //                }
            //                else
            //                {
            //                    if (list[i] == 5)
            //                    {
            //                        listTime.Add("3PM - 4PM");
            //                    }
            //                    else
            //                    {
            //                        if (list[i] == 6)
            //                        {
            //                            listTime.Add("4PM - 5PM");

            //                        }
            //                        else
            //                        {
            //                            listTime.Add(list[i].ToString());
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return Json(list);
        }
    }
}
