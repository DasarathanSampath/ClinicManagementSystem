using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicManagement.ClinicModel
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string PatientName { get; set; }
        public int? PatientAge { get; set; }
        public string PatientContactNumber { get; set; }
        public string PatientAddress { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
