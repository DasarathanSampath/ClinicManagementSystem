using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicManagement.ClinicModel
{
    public partial class Appointment
    {
        public int BookingNumber { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? BookingSlot { get; set; }
        public string AppDoctor { get; set; }
        public string BkdPatient { get; set; }

        public virtual Doctor AppDoctorNavigation { get; set; }
        public virtual Patient BkdPatientNavigation { get; set; }
    }
}
