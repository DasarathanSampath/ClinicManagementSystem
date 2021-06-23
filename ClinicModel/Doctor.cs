using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicManagement.ClinicModel
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string DoctorName { get; set; }
        public int? DoctorAge { get; set; }
        public string DoctorContactNumber { get; set; }
        public string DoctorSpecialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
