using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{    
    public class AppointmentDropDowns
    {        
        public IEnumerable<ClinicModel.Appointment> FilteredData { set; get; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ListOfDoctors { set; get; }
        //public List<string> ListOfDoctors { get; set; }
        public string SelectedDoctor { set; get; }
        public int BookingNumber { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? BookingSlot { get; set; }
        public string AppDoctor { get; set; }
        public string BkdPatient { get; set; }

    }
    //public class DoctorsList
    //{
    //    public string ListOfDoctors;
    //}
}
